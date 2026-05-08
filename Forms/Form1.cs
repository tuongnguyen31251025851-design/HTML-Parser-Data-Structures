using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace HTMLParseProject_V1
{
    public partial class Form1 : Form
    {             
        private MyQueue tagQueue; // Hàng đợi lưu trữ danh sách các thẻ (tokens) đã tách được từ văn bản theo thứ tự FIFO
        private MyStack checkStack; // Ngăn xếp dùng để đối soát các cặp thẻ đóng/mở (LIFO) 
        private MyStack nodeStack; // Ngăn xếp hỗ trợ dựng cây DOM, dùng để xác định Node cha hiện tại khi thêm các Node con
        private HTMLNode rootDOM; //Node gốc (Root) của cây dữ liệu DOM, đại diện cho toàn bộ tài liệu HTML (thường là DOCUMENT)
        private bool hasError = false; // Biến cờ hiệu (Flag) để đánh dấu chương trình có đang gặp lỗi cú pháp hay không
        private string textBuffer = ""; // Bộ nhớ đệm dùng để trích xuất và lưu trữ phần nội dung văn bản (Text) nằm ngoài các thẻ HTML
        [System.Runtime.InteropServices.DllImport("user32.dll")] // Hàm thư viện Windows (API) dùng để tạm dừng việc vẽ lại giao diện (giảm giật lag khi cập nhật TreeView/RichTextBox)
        private static extern bool LockWindowUpdate(IntPtr hWndLock);

        // Lớp đại diện cho một đơn vị dữ liệu (Token) là thẻ HTML
        public class TagToken
        {
            // Tên của thẻ HTML sau khi bóc tách (Ví dụ: "div", "p", "/div", "img")
            // Dùng để đối soát tên thẻ trong Stack
            public string Name;
            // Vị trí dòng của thẻ trong văn bản nhập vào
            // Mục đích: Để thông báo chính xác lỗi nằm ở dòng nào nếu cú pháp sai
            public int Line;
        }

        // Hàm khởi tạo của lớp Form1 (Constructor)
        // Được gọi ngay khi đối tượng Form1 được tạo ra trong bộ nhớ
        public Form1()
        {
            // Phương thức bắt buộc của WinForms để khởi tạo các thành phần giao diện
            // (như Button, TextBox, RichTextBox, TreeView...) được thiết kế từ ToolBox
            InitializeComponent();
        }

        // --- HÀM XỬ LÝ CHÍNH: KẾT HỢP QUEUE VÀ STACK ---
        private void btn_PhanTich_Click(object sender, EventArgs e)
        {
            // Danh sách các thẻ đặc biệt không cần thẻ đóng theo chuẩn HTML
            string[] selfClosingTags = { "img", "br", "hr", "input", "meta", "link" };
            HTMLNode errorNode = null; // Biến tạm để nhớ Node bị lỗi

            // Làm mới bảng theo vết để bắt đầu ghi nhật ký chạy thuật toán
            rtb_Trace.Clear();
            rtb_Trace.AppendText("=== BẮT ĐẦU THEO VẾT THUẬT TOÁN ===\n");
           
            rtb_OutputResult.Clear();
            string textBuffer = ""; // Lưu trữ nội dung văn bản thuần
            string errorLog = ""; // Lưu trữ thông báo lỗi cụ thể
            bool hasError = false; // Biến cờ đánh dấu trạng thái lỗi

            // Khởi tạo các cấu trúc dữ liệu tự xây dựng           
            MyQueue tagQueue = new MyQueue(); // Chứa các thẻ chờ phân tích (FIFO)         
            MyStack checkStack = new MyStack(); // Kiểm tra tính cân bằng đóng/mở (LIFO)
            MyDictionary dict = new MyDictionary(); // Danh mục thẻ hợp lệ

            // --- DỰNG CÂY DOM ---
            rootDOM = new HTMLNode("DOCUMENT"); // Node gốc để chứa toàn bộ các thẻ
            MyStack nodeStack = new MyStack();  // Quản lý cấp bậc cha-con cho cây DOM      
            nodeStack.Push(rootDOM);            // Gốc DOCUMENT luôn là cha đầu tiên     

            string input = rtb_InputHTML.Text;
            if (string.IsNullOrEmpty(input)) return;

            int currentLine = 1;
            string tempTag = "";
            bool isInsideTag = false;

            // --- BƯỚC 1: DUYỆT VÀ TÁCH THẺ (LEXER) ---           
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '\n') currentLine++; // Theo dõi số dòng để báo lỗi chính xác

                if (c == '<')
                {
                    // KỸ THUẬT XỬ LÝ BẪY: Kiểm tra nếu sau '<' là khoảng trắng thì coi là văn bản (vd: < 5)                   
                    if (i + 1 < input.Length && !char.IsWhiteSpace(input[i + 1]))
                    {
                        isInsideTag = true;
                        tempTag = "";
                        continue;
                    }
                    else
                    {
                        textBuffer += c; // Coi dấu '<' này là văn bản bình thường
                        continue;
                    }
                }

                if (c == '>' && isInsideTag)
                {
                    isInsideTag = false;
                    // Chuẩn hóa: Loại bỏ khoảng trắng và đưa về chữ thường                   
                    string fullTag = tempTag.Trim().ToLower();
                                       
                    // XỬ LÝ BẪY THUỘC TÍNH: Tách lấy tên thẻ chính, bỏ qua các thuộc tính (vd: <div class="a"> lấy "div")
                    string tagName = fullTag.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];

                    // Kiểm tra tính hợp lệ trong Dictionary
                    string cleanName = tagName.StartsWith("/") ? tagName.Substring(1) : tagName;

                    // Chỉ nạp vào Queue nếu thẻ nằm trong Dictionary hoặc là thẻ đóng hợp lệ
                    if (dict.IsTagValid(cleanName) || tagName.StartsWith("/"))
                    {                      
                        tagQueue.Enqueue(new TagToken { Name = tagName, Line = currentLine });
                        rtb_Trace.AppendText($"[Queue] Đã Enqueue thẻ: <{tagName}> tại dòng {currentLine}\n");
                    }
                    else
                    {
                        // Thẻ lạ/không tồn tại sẽ được xử lý như văn bản thuần
                        textBuffer += "<" + tempTag + ">";
                        // Thông báo thẻ lạ bị coi là văn bản
                        rtb_Trace.AppendText($"[Info] Thẻ <{tagName}> không có trong Dict, coi là văn bản.\n");
                    }
                    rtb_Trace.ScrollToCaret(); // Tự động cuộn
                    tempTag = "";
                    continue;
                }
                if (isInsideTag) tempTag += c; // Đang trong cặp < >, nhặt ký tự tạo tên thẻ
                else if (c != '\r') textBuffer += c; // Ngoài cặp < >, nhặt ký tự tạo nội dung văn bản
            }

            // --- BƯỚC 2: ĐỐI SOÁT BẰNG STACK (PARSER) ---
            while (!tagQueue.IsEmpty())
            {
                TagToken currentTag = (TagToken)tagQueue.Dequeue();
                // Loại bỏ dấu '/' để lấy tên gốc so sánh với mảng thẻ tự đóng
                string cleanName = currentTag.Name.Replace("/", "").Trim().ToLower();

                if (currentTag.Name.StartsWith("/")) // XỬ LÝ THẺ ĐÓNG
                {
                    // LỖI: Có thẻ đóng nhưng Stack rỗng (Thừa thẻ đóng)
                    if (checkStack.IsEmpty())
                    {
                        hasError = true;
                        errorLog = $"❌ LỖI: Thừa thẻ đóng </{cleanName}> tại dòng {currentTag.Line}";
                        if (!nodeStack.IsEmpty()) ((HTMLNode)nodeStack.Peek()).IsError = true;
                        break;
                    }

                    TagToken openTag = (TagToken)checkStack.Pop();
                    if (openTag.Name.ToLower() == cleanName)
                    {
                        rtb_Trace.AppendText($"[Stack] Khớp: Đóng </{cleanName}>\n");
                        nodeStack.Pop(); // Kết thúc phạm vi của thẻ cha, quay về cấp trên
                    }
                    else
                    {
                        // LỖI: Sai thứ tự lồng nhau (vd: <b><i></b></i>)
                        hasError = true;
                        errorLog = $"❌ LỖI dòng {currentTag.Line}: Sai thứ tự. Đóng </{cleanName}> nhưng chờ </{openTag.Name}>";
                        break;
                    }
                }
                else // XỬ LÝ THẺ MỞ
                {
                    // KIỂM TRA THẺ TỰ ĐÓNG (img, br, hr...)
                    bool isSelfClosing = selfClosingTags.Contains(cleanName);

                    if (isSelfClosing)
                    {
                        // Logic: Thêm vào cây DOM nhưng không đẩy vào Stack (vì không có thẻ đóng)
                        HTMLNode newNode = new HTMLNode(currentTag.Name);
                        if (!nodeStack.IsEmpty())
                        {
                            HTMLNode parent = (HTMLNode)nodeStack.Peek();
                            parent.AddChild(newNode);
                        }
                        rtb_Trace.AppendText($"[DOM] Thêm thẻ tự đóng: <{cleanName}>\n");
                    }
                    else
                    {
                        // Logic thẻ cặp: Push vào Stack để chờ thẻ đóng tương ứng                      
                        checkStack.Push(currentTag);

                        HTMLNode newNode = new HTMLNode(currentTag.Name);
                        if (!nodeStack.IsEmpty())
                        {
                            HTMLNode parent = (HTMLNode)nodeStack.Peek();
                            parent.AddChild(newNode); // Gắn vào cha hiện tại
                            nodeStack.Push(newNode); // Đưa chính nó vào Stack để làm cha cho các thẻ con tiếp theo
                        }
                        rtb_Trace.AppendText($"[Stack] PUSH thẻ mở: <{currentTag.Name}>\n");
                    }
                }
            }
            // --- KIỂM TRA THẺ QUÊN ĐÓNG (Dư thẻ mở) ---
            // Sau khi đã duyệt hết Queue, nếu Stack vẫn còn phần tử nghĩa là có thẻ mở nhưng thiếu thẻ đóng tương ứng.
            if (!hasError && !checkStack.IsEmpty())
            {
                // Lấy thẻ nằm trên cùng của Stack ra để xác định thẻ nào đang bị thiếu đóng
                TagToken unclosed = (TagToken)checkStack.Pop();

                // Thiết lập màu đỏ cho dòng nhật ký lỗi trong bảng Trace
                rtb_Trace.SelectionColor = Color.Red;
                rtb_Trace.AppendText($"[Stack Error] Thẻ <{unclosed.Name}> quên chưa đóng!\n");

                // Ghi nhận thông báo lỗi chi tiết kèm số dòng để người dùng dễ dàng chỉnh sửa
                errorLog = $"❌ LỖI: Thẻ <{unclosed.Name}> mở ở dòng {unclosed.Line} chưa được đóng.";

                // Đánh dấu trạng thái lỗi để chương trình không xác nhận "Hợp lệ" ở bước cuối
                hasError = true;
            }

            // --- BƯỚC 3: XUẤT KẾT QUẢ VÀ HIỂN THỊ GIAO DIỆN ---
            if (hasError)
            {
                // TRƯỜNG HỢP CÓ LỖI: Hiển thị thông báo lỗi màu đỏ tại ô kết quả
                rtb_OutputResult.SelectionColor = Color.Red;
                rtb_OutputResult.AppendText(errorLog);

                // Cập nhật nhật ký truy vết (Trace) để thông báo dừng phân tích do lỗi
                rtb_Trace.SelectionColor = Color.Red;
                rtb_Trace.AppendText("=== PHÂN TÍCH DỪNG: CÓ LỖI CÚ PHÁP ===\n");
                rtb_Trace.ScrollToCaret();
            }
            else
            {
                // TRƯỜNG HỢP HỢP LỆ: Hiển thị nội dung văn bản thuần (đã lọc bỏ thẻ HTML)
                rtb_OutputResult.SelectionColor = Color.Black;
                rtb_OutputResult.AppendText(textBuffer.Trim());
                rtb_OutputResult.AppendText("\n\n----------------------------\n");

                // Thông báo xác nhận cấu trúc HTML hoàn toàn chính xác
                rtb_OutputResult.SelectionColor = Color.Green;
                rtb_OutputResult.AppendText("✅ Cấu trúc hợp lệ!");

                // Ghi nhận trạng thái thành công vào nhật ký truy vết
                rtb_Trace.SelectionColor = Color.Lime; 
                rtb_Trace.AppendText("=== PHÂN TÍCH HOÀN TẤT: THÀNH CÔNG ===\n");
                rtb_Trace.ScrollToCaret(); 
            }

            // --- CẬP NHẬT CÂY DOM (Document Object Model) LÊN GIAO DIỆN ---
            tv_DOM.Nodes.Clear(); // Làm sạch cây cũ để tránh chồng chéo dữ liệu
            TreeNode visualRoot = new TreeNode("HTML Document"); // Tạo nút gốc trên giao diện (TreeView)
            tv_DOM.Nodes.Add(visualRoot);

            // Đệ quy đổ dữ liệu từ cấu trúc cây HTMLNode (Logic) sang TreeView (Giao diện)        
            PopulateTreeView(rootDOM, visualRoot, errorNode);

            // Mở rộng toàn bộ các nhánh cây để người dùng quan sát được toàn bộ cấu trúc phân cấp
            tv_DOM.ExpandAll(); 

            // Thực hiện tô màu cú pháp (Syntax Highlighting) cho ô nhập liệu để tăng tính thẩm mỹ
            HighlightSyntax(rtb_InputHTML);
        }


        // --- NHÓM TIỆN ÍCH GIAO DIỆN & TRẢI NGHIỆM NGƯỜI DÙNG (UX/UI) ---

        // Sự kiện tự động cập nhật số dòng và tô màu cú pháp khi văn bản thay đổi
        private void rtb_InputHTML_TextChanged(object sender, EventArgs e)
        {            
            // 1. Tạo cột số dòng bên trái tương ứng với số lượng dòng thực tế
            string lineNumbers = "";
            int totalLines = rtb_InputHTML.Lines.Length;
            if (totalLines <= 0) totalLines = 1;
            for (int i = 1; i <= totalLines; i++) lineNumbers += i + "\n";
            rtb_LineNumbers.Text = lineNumbers;

            // 2. Gọi hàm tô màu cú pháp (thẻ xanh, thuộc tính đỏ...) ngay khi đang gõ
            HighlightSyntax(rtb_InputHTML);

            // 3. Kỹ thuật đồng bộ hóa thanh cuộn:
            // Đảm bảo số dòng bên trái luôn khớp với vị trí dòng đang hiển thị trong ô nhập liệu
            int firstCharIndex = rtb_InputHTML.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = rtb_InputHTML.GetLineFromCharIndex(firstCharIndex);
            rtb_LineNumbers.SelectionStart = rtb_LineNumbers.GetFirstCharIndexFromLine(firstLine);
            rtb_LineNumbers.ScrollToCaret();
        }
              
        // Xử lý nút 'Xóa': Khôi phục trạng thái ban đầu của toàn bộ chương trình
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            // 1. Dọn dẹp nội dung các khung nhập liệu và hiển thị kết quả
            rtb_InputHTML.Clear();
            rtb_OutputResult.Clear();
            rtb_Trace.Clear();

            // 2. Giải phóng bộ nhớ hiển thị của cây DOMTree
            tv_DOM.Nodes.Clear();
                        
            // 3. Làm mới các bảng theo dõi trạng thái thuật toán trên giao diện (ListView)
            lv_Queue.Items.Clear(); // Xóa các dòng trong bảng Hàng đợi
            lv_Stack.Items.Clear(); // Xóa các dòng trong bảng Ngăn xếp

            // 4. Khởi tạo lại (Reset) các cấu trúc dữ liệu nội bộ
            // Mục đích: Tránh xung đột dữ liệu cũ khi người dùng bắt đầu phân tích mã mới
            tagQueue = new MyQueue();
            checkStack = new MyStack();
            nodeStack = new MyStack();
            hasError = false;

            // 5. Điều hướng tiêu điểm (Focus) về ô nhập liệu để người dùng có thể gõ ngay
            rtb_InputHTML.Focus();
        }

        // Hiển thị danh sách các mã HTML mẫu giúp người dùng kiểm thử nhanh       
        private void btn_MauThu_Click(object sender, EventArgs e)
        {
            // Hiển thị menu ngữ cảnh (ContextMenuStrip) chứa các bộ testcase mẫu ngay dưới chân nút bấm
            ctx_SampleMenu.Show(btn_MauThu, new Point(0, btn_MauThu.Height));
        }


        // --- NHÓM MENU FILE: QUẢN LÝ TỆP TIN & HỆ THỐNG ---

        // 1. Chức năng Mở file: Nạp dữ liệu HTML từ ổ đĩa vào chương trình        
        private void menu_MoFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            // Thiết lập bộ lọc chỉ hiển thị các định dạng tệp tin HTML phổ biến
            openDlg.Filter = "HTML Files (*.html;*.htm)|*.html;*.htm|All Files (*.*)|*.*";
            openDlg.Title = "Chọn file HTML để phân tích";

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Đọc toàn bộ văn bản từ tệp nguồn và đưa vào khung soạn thảo                   
                    string content = File.ReadAllText(openDlg.FileName);
                    rtb_InputHTML.Text = content;

                    // Tự động tô màu cú pháp ngay sau khi nạp file để tăng trải nghiệm người dùng
                    HighlightSyntax(rtb_InputHTML);

                    // Xử lý ngoại lệ nếu tệp đang bị khóa hoặc không có quyền truy cập
                    MessageBox.Show("Mở file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. Chức năng Lưu file: Xuất báo cáo kết quả phân tích ra tệp văn bản (.txt)
        private void menu_LuuFile_Click(object sender, EventArgs e)
        {
            // Kiểm tra tính sẵn sàng: Chỉ cho phép lưu khi đã thực hiện phân tích và có kết quả
            if (string.IsNullOrEmpty(rtb_OutputResult.Text))
            {
                MessageBox.Show("Chưa có kết quả để lưu!", "Nhắc nhở");
                return;
            }

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Text Files (*.txt)|*.txt";
            saveDlg.FileName = "KetQuaPhanTich.txt"; // Tên file mặc định chuyên nghiệp

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveDlg.FileName, rtb_OutputResult.Text);
                    MessageBox.Show("Lưu kết quả thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
                }
            }
        }

        // 3. Chức năng Thoát: Đóng ứng dụng an toàn
        private void menu_Thoat_Click(object sender, EventArgs e)
        {
            // Sử dụng hộp thoại xác nhận (Yes/No) để tránh việc người dùng bấm nhầm làm mất dữ liệu
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit(); // Giải phóng tài nguyên và đóng hoàn toàn ứng dụng
            }
        }

        // --- NHÓM TRỢ GIÚP & THÔNG TIN ---

        // Chức năng hiển thị hướng dẫn vận hành phần mềm
        private void menu_HuongDan_Click(object sender, EventArgs e)
        {
            // Nội dung hướng dẫn được trình bày theo từng bước logic để người dùng dễ tiếp cận
            string hd = "HƯỚNG DẪN SỬ DỤNG PHẦN MỀM\n\n" +
                        "1. NHẬP DỮ LIỆU: Nhập mã HTML vào ô bên trái hoặc chọn 'Mở file'.\n\n" +
                        "2. CHỌN CHẾ ĐỘ:\n" +
                        "   - 'PHÂN TÍCH': Kiểm tra nhanh và hiển thị cây DOM ngay lập tức.\n" +
                        "   - 'BƯỚC TIẾP': Theo dõi thuật toán xử lý từng thẻ một cách chi tiết.\n" +
                        "   - 'CHẠY HẾT': Tự động chạy toàn bộ quy trình.\n\n" +
                        "3. KẾT QUẢ: Xem thông báo lỗi (màu đỏ) hoặc hợp lệ (màu xanh) & CâyDOM ở tab bên phải.\n\n" +
                        "Lưu ý: Chương trình hỗ trợ chuẩn thẻ tự đóng (img, br, hr, input...). " +
                        "Sử dụng Queue để quản lý danh sách thẻ và Stack để kiểm tra tính cân bằng.";
            // Hiển thị hộp thoại thông tin với biểu tượng 'Information' chuyên nghiệp
            MessageBox.Show(hd, "Hướng dẫn sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Chức năng hiển thị thông tin nhận diện sinh viên thực hiện đồ án
        private void menu_TacGia_Click(object sender, EventArgs e)
        {
            // Thông tin định danh bao gồm Họ tên, MSSV, Đơn vị đào tạo và Chuyên ngành
            // Đây là phần quan trọng để xác nhận quyền sở hữu trí tuệ đối với sản phẩm phần mềm
            MessageBox.Show("Nhóm sinh viên thực hiện đồ án Đề tài số 1\nUEH University\nChuyên ngành: An toàn thông tin", "Thông tin tác giả");
        }

        // --- NHÓM QUẢN LÝ MẪU THỬ (TESTCASES) ---

        // 1. Mẫu thử chuẩn: Kiểm tra kịch bản HTML hoàn hảo không lỗi        
        private void mẫuĐúngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighlightSyntax(rtb_InputHTML);
            rtb_InputHTML.Text = "<html>\r\n  <body>\r\n    <h1>UEH University</h1>\r\n    <p>Chào bạn!</p>\r\n  </body>\r\n</html>";
        }

        // 2. Mẫu lỗi logic: Kiểm tra khả năng phát hiện sai thứ tự lồng nhau (vd: <b><i></b></i>)
        private void lỗiSaiThứTựToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HighlightSyntax(rtb_InputHTML);
            rtb_InputHTML.Text = "<div>\r\n  <p>Lỗi đóng sai: <b><i>Nghiêng Đậm</b></i>\r\n</div>";
        }

        // 3. Mẫu lỗi cấu trúc: Kiểm tra kịch bản quên đóng thẻ (Dư thẻ mở trong Stack)       
        private void lỗiThiếuThẻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighlightSyntax(rtb_InputHTML);
            rtb_InputHTML.Text = "<html>\r\n  <body>\r\n    <div>\r\n      <p>Thẻ div này mở ra nhưng không bao giờ đóng lại...\r\n  </body>\r\n</html>";
        }

        // 4. Mẫu bẫy thuộc tính: Kiểm tra logic tách tên thẻ ra khỏi các thuộc tính (class, id...)       
        private void bẫyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighlightSyntax(rtb_InputHTML);
            rtb_InputHTML.Text = "<div class='test'>\n  <p>Nội dung</p>\n</div>";
        }

        // 5. Mẫu bẫy toán tử: Kiểm tra dấu '<' đóng vai trò là ký tự so sánh (không phải mở đầu thẻ)
        private void bẫyToánTửNângCaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighlightSyntax(rtb_InputHTML);
            rtb_InputHTML.Text = "<div>\n <p>Giá trị < 100</p>\n <b>Đậm</b>\n</div>";
        }

        // 6. Mẫu bẫy định dạng: Kiểm tra khả năng xử lý khi thẻ bị ngắt xuống dòng đột ngột
        private void bẫyXuốngDòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighlightSyntax(rtb_InputHTML);
            rtb_InputHTML.Text = "<div\n class='test'>\n <p\n >Nội dung</p\n>\n</div\n>";
        }
               
        private void rtb_LineNumbers_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_OutputResult_TextChanged(object sender, EventArgs e)
        {

        }


        // --- HÀM HỖ TRỢ HIỂN THỊ TRỰC QUAN (VISUALIZATION) ---

        // Hàm đệ quy: Chuyển đổi từ cây HTMLNode (Logic tự xây dựng) sang TreeView (Giao diện Winform)

        private void PopulateTreeView(HTMLNode customNode, TreeNode winformNode, HTMLNode errorNode)
        {
            // Duyệt qua toàn bộ danh sách các node con của node hiện tại
            for (int i = 0; i < customNode.ChildCount; i++)
            {
                HTMLNode child = customNode.Children[i];

                // Tạo một node mới tương ứng trên giao diện cây Winform
                TreeNode newNode = new TreeNode(child.TagName);

                // --- KIỂM TRA VÀ ĐÁNH DẤU VỊ TRÍ LỖI TRÊN CÂY ---
                if (child.IsError)
                {
                    // Nếu node này được đánh dấu lỗi, hiển thị màu đỏ và chữ in đậm
                    newNode.ForeColor = Color.Red;
                    newNode.Text += " <--- LỖI TẠI ĐÂY";
                    newNode.NodeFont = new Font(tv_DOM.Font, FontStyle.Bold);

                    // Tự động tập trung (focus) vào vị trí lỗi để người dùng thấy ngay
                    tv_DOM.SelectedNode = newNode;
                }

                // Thêm node vừa tạo vào node cha trên giao diện
                winformNode.Nodes.Add(newNode);

                // TIẾP TỤC ĐỆ QUY: Đi sâu xuống các cấp con tiếp theo cho đến khi hết nhánh
                PopulateTreeView(child, newNode, errorNode);
            }
        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void rtb_Trace_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void lv_Queue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Hàm tô màu cú pháp: Tự động nhận diện thẻ HTML và đổi màu sắc để dễ quan sát
        private void HighlightSyntax(RichTextBox rtb)
        {
            // Kiểm tra nếu ô nhập liệu trống thì thoát để tiết kiệm tài nguyên
            if (string.IsNullOrEmpty(rtb.Text)) return;

            // Tối ưu hóa: Khóa việc vẽ lại giao diện để tránh bị nháy màn hình khi tô màu hàng loạt
            LockWindowUpdate(rtb.Handle);

            // Lưu lại vị trí con trỏ và độ dài vùng chọn hiện tại của người dùng
            int originalIndex = rtb.SelectionStart;
            int originalLength = rtb.SelectionLength;

            // --- BƯỚC 1: RESET ĐỊNH DẠNG ---
            // Đưa toàn bộ văn bản về màu mặc định (Gainsboro) và kiểu chữ bình thường           
            rtb.SelectAll();
            rtb.SelectionColor = Color.Gainsboro;
            rtb.SelectionFont = new Font(rtb.Font, FontStyle.Regular);

            // --- BƯỚC 2: TÔ MÀU THẺ HTML ---
            // Sử dụng Regular Expression (Biểu thức chính quy) để tìm tất cả các cụm nằm trong cặp dấu < >
            string pattern = @"<[^>]+>";
            foreach (Match m in Regex.Matches(rtb.Text, pattern))
            {
                // Chọn đoạn văn bản khớp với biểu thức (từ dấu < đến >)
                rtb.Select(m.Index, m.Length);

                // Thiết lập màu xanh dương (DodgerBlue) và in đậm cho thẻ
                rtb.SelectionColor = Color.DodgerBlue;
                rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
            }
                        
            // --- BƯỚC 3: HOÀN TÁC TRẠNG THÁI ---
            // Trả con trỏ chuột về đúng vị trí cũ để người dùng tiếp tục gõ mà không bị gián đoạn
            rtb.SelectionStart = originalIndex;
            rtb.SelectionLength = originalLength;

            
            // Kỹ thuật xử lý con trỏ: Đảm bảo màu sắc của ký tự tiếp theo người dùng gõ là màu mặc định
            if (originalLength == 0)
            {
                rtb.SelectionColor = Color.Gainsboro;
            }

            // Mở khóa giao diện sau khi đã hoàn tất việc tô màu
            LockWindowUpdate(IntPtr.Zero);

            // Ép RichTextBox cập nhật lại hình ảnh hiển thị ngay lập tức
            rtb.Invalidate();
        }

        // --- CHỨC NĂNG MÔ PHỎNG TỰ ĐỘNG (ANIMATION) ---

        // Chạy toàn bộ quy trình phân tích theo từng bước với hiệu ứng trễ (Delay)
        private async void btn_RunAll_Click(object sender, EventArgs e)
        {
            // 1. Làm mới lại toàn bộ dữ liệu, Stack và Queue để bắt đầu chạy từ đầu
            PrepareData(); // Nạp mới từ đầu

            // 2. Vòng lặp điều khiển: Tiếp tục chạy chừng nào Hàng đợi (Queue) còn thẻ 
            // và chương trình chưa phát hiện bất kỳ lỗi cú pháp nào.
            while (!tagQueue.IsEmpty() && !hasError)
            {
                // Thực thi logic của một bước phân tích (Dequeue, Push/Pop Stack, Dựng DOM)
                ExecuteOneStep();

                // Kỹ thuật lập trình bất đồng bộ: Tạm dừng chương trình trong 200 miligiây
                // Mục đích: Giúp người dùng có thể quan sát bằng mắt thường sự biến đổi 
                // của các bảng dữ liệu và sự nhảy thẻ giữa Queue và Stack.
                await System.Threading.Tasks.Task.Delay(200); // Đợi một chút để thấy hiệu ứng nhảy bảng
            }
            // Lưu ý: Việc dùng 'async/await' giúp giao diện (UI) không bị treo (Not Responding)
            // trong khi chương trình đang thực hiện quá trình Delay.
        }


        // --- HÀM CHUẨN BỊ DỮ LIỆU (DATA PREPARATION) ---
        // Nhiệm vụ: Reset toàn bộ trạng thái cũ và thực hiện bóc tách thẻ (Lexing) để nạp vào Queue
        private void PrepareData()
        {
            // 1. LÀM SẠCH GIAO DIỆN: Xóa nội dung cũ trên các bảng theo dõi và cây DOM
            rtb_Trace.Clear();
            lv_Queue.Items.Clear();
            lv_Stack.Items.Clear();
            tv_DOM.Nodes.Clear();

            // 2. KHỞI TẠO LẠI CẤU TRÚC DỮ LIỆU: Tạo mới các Stack, Queue và Node gốc cho cây DOM
            tagQueue = new MyQueue();
            checkStack = new MyStack();
            nodeStack = new MyStack();
            rootDOM = new HTMLNode("DOCUMENT");
            nodeStack.Push(rootDOM); // Đưa Node gốc vào Stack để bắt đầu dựng cây
            hasError = false; // Reset trạng thái lỗi

            // 3. KIỂM TRA ĐẦU VÀO: Nếu ô nhập liệu trống thì dừng lại
            string input = rtb_InputHTML.Text;
            if (string.IsNullOrEmpty(input)) return;

            int currentLine = 1;
            bool isInsideTag = false;
            string tempTag = "";

            // 4. PHÂN TÍCH TỪ VỰNG (LEXING): Duyệt chuỗi văn bản để tìm và bóc tách các thẻ HTML
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '\n') currentLine++; // Đếm dòng để định vị thẻ

                // Nhận diện ký tự mở thẻ '<', loại bỏ trường hợp có khoảng trắng phía sau (tránh bẫy toán tử)
                if (c == '<' && i + 1 < input.Length && !char.IsWhiteSpace(input[i + 1]))
                {
                    isInsideTag = true;
                    tempTag = "";
                    continue;
                }
                // Nhận diện ký tự đóng thẻ '>'
                if (c == '>' && isInsideTag)
                {
                    isInsideTag = false;
                    // Tách tên thẻ chính (bỏ qua thuộc tính) và chuyển về chữ thường (Case-insensitive)
                    string tagName = tempTag.Trim().Split(' ', '\n', '\r')[0].ToLower();
                    // Nạp thẻ vào Hàng đợi (Queue) để chờ xử lý ở các bước tiếp theo
                    tagQueue.Enqueue(new TagToken { Name = tagName, Line = currentLine });
                    tempTag = "";
                    continue;
                }
                // Nạp thẻ vào Hàng đợi (Queue) để chờ xử lý ở các bước tiếp theo
                if (isInsideTag) tempTag += c;
            }

            // 5. KẾT THÚC CHUẨN BỊ: Thông báo sẵn sàng và cập nhật bảng hiển thị trên giao diện
            rtb_Trace.AppendText("--- ĐÃ NẠP DỮ LIỆU: Bấm 'Bước tiếp' để bắt đầu phân tích ---\n");
            UpdateAlgorithmTables(); // Để hiện danh sách thẻ đang chờ trong Queue           
        }

        // --- HÀM XỬ LÝ VÀ HIỂN THỊ LỖI (ERROR HANDLING) ---
        // Nhiệm vụ: Dừng quy trình, thông báo lỗi bằng màu sắc và đánh dấu vị trí lỗi trên cây DOM
        private void ShowError(string message)
        {
            // 1. Đánh dấu trạng thái hệ thống đang gặp lỗi
            hasError = true;
            // 2. Hiển thị thông báo lỗi màu đỏ tại ô Kết quả (Output)
            rtb_OutputResult.SelectionColor = Color.Red;
            rtb_OutputResult.AppendText("\n❌ " + message);
            // 3. Cập nhật nhật ký truy vết (Trace) để người dùng theo dõi được thời điểm phát sinh lỗi
            rtb_Trace.SelectionColor = Color.Red;
            rtb_Trace.AppendText($"\n[ERROR] {message}\n");
            rtb_Trace.ScrollToCaret();

            // 4. LOGIC ĐÁNH DẤU LỖI TRÊN CÂY DOM:
            // Tìm đối tượng Node cuối cùng được xử lý để nhuộm đỏ trên giao diện cây
            if (!nodeStack.IsEmpty())
            {
                // Lấy Node cha hiện tại đang nằm trên đỉnh Stack
                HTMLNode currentParent = (HTMLNode)nodeStack.Peek();
                // Nếu cha đã có con, đánh dấu Node con cuối cùng là Node gây lỗi
                if (currentParent.ChildCount > 0)
                    currentParent.Children[currentParent.ChildCount - 1].IsError = true;
                else
                    // Nếu chưa có con, đánh dấu chính Node cha này bị lỗi (ví dụ lỗi thiếu thẻ đóng)
                    currentParent.IsError = true;
            }
            // 5. CẬP NHẬT GIAO DIỆN: Vẽ lại toàn bộ cây DOM để áp dụng màu đỏ vào các Node bị đánh dấu IsError
            UpdateDOMUI(); // Vẽ lại cây để thấy màu đỏ
        }

        private void UpdateDOMUI()
        {
            tv_DOM.Nodes.Clear();
            TreeNode visualRoot = new TreeNode("HTML Document");
            tv_DOM.Nodes.Add(visualRoot);

            // Gọi hàm đệ quy mà bạn đã viết sẵn ở trên
            // Ở đây ta truyền null cho errorNode vì thông tin lỗi đã nằm trong child.IsError
            PopulateTreeView(rootDOM, visualRoot, null);

            tv_DOM.ExpandAll();
        }

        // --- HÀM KIỂM TRA CUỐI CÙNG (FINAL VALIDATION) ---
        // Nhiệm vụ: Xác nhận trạng thái cuối cùng của Ngăn xếp để đưa ra kết luận về tính hợp lệ
        private void FinalCheck()
        {
            // Nếu sau khi duyệt hết các thẻ mà Stack vẫn còn phần tử
            // Nghĩa là có ít nhất một thẻ mở chưa có thẻ đóng tương ứng (mất cân bằng)
            if (!checkStack.IsEmpty())
            {
                // Lấy thẻ "mồ côi" cuối cùng ra để thông báo cho người dùng
                TagToken unclosed = (TagToken)checkStack.Pop();

                // Gọi hàm hiển thị lỗi để nhuộm đỏ giao diện và dừng phân tích
                ShowError($"Thẻ <{unclosed.Name}> mở ở dòng {unclosed.Line} nhưng chưa được đóng!");
            }
            else
            {
                // TRƯỜNG HỢP THÀNH CÔNG: Stack rỗng hoàn toàn (Mọi thẻ mở đều đã được đóng đúng cách)

                // Hiển thị thông báo hợp lệ màu xanh tại ô Kết quả
                rtb_OutputResult.SelectionColor = Color.Green;
                rtb_OutputResult.AppendText("\n✅ Cấu trúc hợp lệ!");

                // Ghi nhận trạng thái hoàn tất rực rỡ vào nhật ký truy vết (Trace)
                rtb_Trace.SelectionColor = Color.Lime;
                rtb_Trace.AppendText("\n=== PHÂN TÍCH THÀNH CÔNG ===\n");
            }
            // Tự động cuộn bảng truy vết xuống dưới cùng để người dùng thấy kết luận
            rtb_Trace.ScrollToCaret();
        }


        // --- HÀM THỰC THI TỪNG BƯỚC (STEP-BY-STEP EXECUTION) ---
        // Nhiệm vụ: Xử lý duy nhất một Token từ Queue và cập nhật trạng thái hệ thống
        private void ExecuteOneStep()
        {
            string[] selfClosingTags = { "img", "br", "hr", "input", "meta", "link" };
            // Kiểm tra điều kiện dừng: Nếu Queue rỗng hoặc hệ thống đang có lỗi thì không chạy tiếp
            if (tagQueue == null || tagQueue.IsEmpty() || hasError) return;

            // Lấy thẻ đầu tiên ra khỏi Hàng đợi (FIFO) để xử lý
            TagToken currentTag = (TagToken)tagQueue.Dequeue();

            // Nhật ký theo vết: Đánh dấu thẻ đang được xử lý bằng màu vàng
            rtb_Trace.SelectionColor = Color.Yellow;
            rtb_Trace.AppendText($"[Step] Đang xử lý: <{currentTag.Name}> (Dòng {currentTag.Line})\n");

            // --- NHÁNH 1: XỬ LÝ THẺ ĐÓNG (CÓ DẤU '/') ---
            if (currentTag.Name.StartsWith("/")) // Thẻ đóng
            {
                // ... (Giữ nguyên logic xử lý thẻ đóng của bạn) ...
                string closeName = currentTag.Name.Substring(1).Trim();

                // LỖI: Nếu Stack rỗng mà gặp thẻ đóng nghĩa là thừa thẻ đóng
                if (checkStack.IsEmpty())
                {
                    ShowError($"Thừa thẻ đóng </{closeName}> tại dòng {currentTag.Line}");
                    return;
                }

                // Lấy thẻ mở gần nhất ra khỏi Stack (LIFO) để đối soát
                TagToken openTag = (TagToken)checkStack.Pop();
                nodeStack.Pop(); // Kết thúc phạm vi của Node hiện tại trên cây DOM

                // Kiểm tra tính tương ứng giữa tên thẻ mở và thẻ đóng
                if (openTag.Name == closeName)
                {
                    rtb_Trace.AppendText($"   -> Khớp với <{openTag.Name}>. Pop Stack.\n");
                }
                else
                {
                    // LỖI: Sai thứ tự lồng nhau (vd: <b><i></b>)
                    ShowError($"Sai thứ tự. Đóng </{closeName}> nhưng chờ <{openTag.Name}>");
                    return;
                }
            }

            // --- NHÁNH 2: XỬ LÝ THẺ MỞ ---
            else // Thẻ mở
            {
                // Kiểm tra xem thẻ này có nằm trong danh sách thẻ tự đóng (Single Tags) hay không
                bool isSelfClosing = false;
                foreach (string s in selfClosingTags)
                {
                    if (currentTag.Name.ToLower() == s)
                    {
                        isSelfClosing = true;
                        break;
                    }
                }

                if (isSelfClosing)
                {
                    // TRƯỜNG HỢP THẺ TỰ ĐÓNG: Chỉ thêm vào cây DOM, không đưa vào Stack kiểm lỗi                    
                    rtb_Trace.AppendText($"   -> Thẻ tự đóng <{currentTag.Name}>. Chỉ nạp vào DOM, không Push Stack.\n");

                    // Chỉ thêm vào cây DOM như một nút lá
                    HTMLNode newNode = new HTMLNode(currentTag.Name);
                    HTMLNode parent = (HTMLNode)nodeStack.Pop(); // Lấy cha tạm thời
                    parent.AddChild(newNode);// Gắn con vào
                    nodeStack.Push(parent);// Trả cha về lại Stack                   
                }

                else
                {
                    // TRƯỜNG HỢP THẺ CẶP: Push vào Stack để chờ thẻ đóng trong tương lai                   
                    checkStack.Push(currentTag);
                    rtb_Trace.AppendText($"   -> Push <{currentTag.Name}> vào Stack.\n");

                    HTMLNode newNode = new HTMLNode(currentTag.Name);
                    HTMLNode parent = (HTMLNode)nodeStack.Pop();
                    parent.AddChild(newNode);
                    nodeStack.Push(parent);
                    nodeStack.Push(newNode); // Đưa Node này vào Stack để các thẻ tiếp theo trở thành con của nó
                }
            }

            // Cập nhật giao diện sau mỗi bước để người dùng thấy sự thay đổi
            UpdateDOMUI(); // Vẽ lại cây DOM
            UpdateAlgorithmTables(); // Cập nhật danh sách các Item trong ListView (Queue & Stack)

            // Nếu đây là thẻ cuối cùng trong Queue, tiến hành kiểm tra tổng thể lần cuối
            if (tagQueue.IsEmpty())
            {
                FinalCheck();
            }
        }

        // --- HÀM CẬP NHẬT TRẠNG THÁI THUẬT TOÁN LÊN GIAO DIỆN(UI UPDATE) ---
        // Nhiệm vụ: Đổ dữ liệu từ các cấu trúc dữ liệu (Stack, Queue) vào các bảng hiển thị (ListView)
        private void UpdateAlgorithmTables()
        {
            // --- 1. CẬP NHẬT BẢNG HÀNG ĐỢI (QUEUE) ---
            lv_Queue.Items.Clear();
            if (tagQueue != null)
            {
                // Duyệt qua danh sách các thẻ đang chờ xử lý trong Queue
                foreach (var item in tagQueue.ToArray())
                {
                    if (item is TagToken t)
                    {
                        // Hiển thị Tên thẻ và số dòng tương ứng vào bảng Queue
                        ListViewItem lvi = new ListViewItem(t.Name);
                        lvi.SubItems.Add(t.Line.ToString());
                        lv_Queue.Items.Add(lvi);
                    }
                }
            }

            // --- 2. CẬP NHẬT BẢNG NGĂN XẾP (STACK) ---
            lv_Stack.Items.Clear();
            if (checkStack != null && !checkStack.IsEmpty())
            {
                var items = checkStack.ToArray();
                // KỸ THUẬT QUAN TRỌNG: Duyệt ngược mảng (từ cuối về đầu)
                // Mục đích: Để thẻ mới nhất (đỉnh Stack) luôn xuất hiện ở dòng đầu tiên của bảng
                // Điều này giúp người dùng dễ dàng quan sát cơ chế LIFO (Vào sau - Ra trước)
               
                for (int i = items.Length - 1; i >= 0; i--)
                {
                    if (items[i] is TagToken t)
                    {
                        ListViewItem lvi = new ListViewItem(t.Name);
                        lvi.SubItems.Add(t.Line.ToString());
                        lv_Stack.Items.Add(lvi);
                    }
                }
            }
            // --- 3. ĐỒNG BỘ HÓA GIAO DIỆN (UI SYNCHRONIZATION) ---
            // Ép các bảng phải vẽ lại ngay lập tức thay vì chờ đợi luồng hệ thống
            lv_Stack.Refresh();
            lv_Queue.Refresh();
            // Lệnh này giúp giao diện không bị "đóng băng", cho phép các sự kiện khác (như vẽ lại màu sắc) 
            // được xử lý song song, tạo hiệu ứng mượt mà khi chạy mô phỏng.
            Application.DoEvents();
        }

        // --- ĐIỀU KHIỂN CHẾ ĐỘ CHẠY TỪNG BƯỚC (STEP-BY-STEP CONTROLLER) ---
        private void btn_Step_Click_1(object sender, EventArgs e)
        {
            // TRƯỜNG HỢP 1: Nạp dữ liệu khởi đầu
            // Điều kiện: Nếu Queue chưa tồn tại, hoặc hệ thống đang trống (vừa mở app hoặc vừa bấm 'Xóa')            
            if (tagQueue == null || (tagQueue.IsEmpty() && checkStack.IsEmpty() && !hasError))
            {
                // Thực hiện bóc tách thẻ từ ô nhập liệu và nạp vào Hàng đợi
                PrepareData();

                // Dừng lại tại đây để người dùng có thời gian quan sát danh sách thẻ vừa nạp vào bảng Queue
                return;
            }

            // TRƯỜNG HỢP 2: Tự động làm mới (Auto-Reset)
            // Điều kiện: Nếu đã xử lý hết thẻ (Queue rỗng) và đã kết thúc bài (hợp lệ hoặc có lỗi)
            // nhưng người dùng vẫn bấm 'Bước tiếp'
            if (tagQueue.IsEmpty() && (checkStack.IsEmpty() || hasError))
            {
                // Tự động nạp lại dữ liệu từ đầu để bắt đầu một chu kỳ phân tích mới
                PrepareData();
                return;
            }

            // TRƯỜNG HỢP 3: THỰC THI THUẬT TOÁN
            // Nếu dữ liệu đã sẵn sàng và còn thẻ trong Queue, tiến hành xử lý đúng 1 Token
            ExecuteOneStep();
        }
       
    }

}

