namespace HTMLParseProject_V1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_MoFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_LuuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Thoat = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_HuongDan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_TacGia = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_PhanTich = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_MauThu = new System.Windows.Forms.Button();
            this.ctx_SampleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mẫuĐúngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lỗiSaiThứTựToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lỗiThiếuThẻToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bẫyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bẫyToánTửNângCaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bẫyXuốngDòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtb_LineNumbers = new System.Windows.Forms.RichTextBox();
            this.rtb_InputHTML = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtb_OutputResult = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tv_DOM = new System.Windows.Forms.TreeView();
            this.rtb_Trace = new System.Windows.Forms.RichTextBox();
            this.lv_Queue = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_Stack = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Step = new System.Windows.Forms.Button();
            this.btn_RunAll = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.ctx_SampleMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(205)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.trợGiúpToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 10, 0, 8);
            this.menuStrip1.Size = new System.Drawing.Size(1302, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AutoSize = false;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_MoFile,
            this.menu_LuuFile,
            this.menu_Thoat});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(80, 45);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // menu_MoFile
            // 
            this.menu_MoFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_MoFile.Name = "menu_MoFile";
            this.menu_MoFile.Size = new System.Drawing.Size(270, 36);
            this.menu_MoFile.Text = "Mở file HTML";
            this.menu_MoFile.Click += new System.EventHandler(this.menu_MoFile_Click);
            this.menu_MoFile.TextChanged += new System.EventHandler(this.menu_MoFile_Click);
            // 
            // menu_LuuFile
            // 
            this.menu_LuuFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_LuuFile.Name = "menu_LuuFile";
            this.menu_LuuFile.Size = new System.Drawing.Size(270, 36);
            this.menu_LuuFile.Text = "Lưu kết quả";
            this.menu_LuuFile.Click += new System.EventHandler(this.menu_LuuFile_Click);
            this.menu_LuuFile.TextChanged += new System.EventHandler(this.menu_LuuFile_Click);
            // 
            // menu_Thoat
            // 
            this.menu_Thoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Thoat.Name = "menu_Thoat";
            this.menu_Thoat.Size = new System.Drawing.Size(270, 36);
            this.menu_Thoat.Text = "Thoát";
            this.menu_Thoat.Click += new System.EventHandler(this.menu_Thoat_Click);
            this.menu_Thoat.TextChanged += new System.EventHandler(this.menu_Thoat_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.AutoSize = false;
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_HuongDan});
            this.trợGiúpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trợGiúpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(85, 45);
            this.trợGiúpToolStripMenuItem.Text = "&Trợ giúp";
            // 
            // menu_HuongDan
            // 
            this.menu_HuongDan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_HuongDan.Name = "menu_HuongDan";
            this.menu_HuongDan.Size = new System.Drawing.Size(290, 36);
            this.menu_HuongDan.Text = "Hướng dẫn sử dụng";
            this.menu_HuongDan.Click += new System.EventHandler(this.menu_HuongDan_Click);
            this.menu_HuongDan.TextChanged += new System.EventHandler(this.menu_HuongDan_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoSize = false;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_TacGia});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 45);
            this.toolStripMenuItem1.Text = "Thông tin";
            // 
            // menu_TacGia
            // 
            this.menu_TacGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_TacGia.Name = "menu_TacGia";
            this.menu_TacGia.Size = new System.Drawing.Size(270, 36);
            this.menu_TacGia.Text = "Thông tin tác giả";
            this.menu_TacGia.Click += new System.EventHandler(this.menu_TacGia_Click);
            this.menu_TacGia.TextChanged += new System.EventHandler(this.menu_TacGia_Click);
            // 
            // btn_PhanTich
            // 
            this.btn_PhanTich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(205)))));
            this.btn_PhanTich.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_PhanTich.FlatAppearance.BorderSize = 0;
            this.btn_PhanTich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PhanTich.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PhanTich.ForeColor = System.Drawing.Color.White;
            this.btn_PhanTich.Location = new System.Drawing.Point(6, 6);
            this.btn_PhanTich.Margin = new System.Windows.Forms.Padding(6);
            this.btn_PhanTich.Name = "btn_PhanTich";
            this.btn_PhanTich.Size = new System.Drawing.Size(120, 40);
            this.btn_PhanTich.TabIndex = 1;
            this.btn_PhanTich.Text = "Phân tích";
            this.btn_PhanTich.UseVisualStyleBackColor = false;
            this.btn_PhanTich.TextChanged += new System.EventHandler(this.btn_PhanTich_Click);
            this.btn_PhanTich.Click += new System.EventHandler(this.btn_PhanTich_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Xoa.FlatAppearance.BorderSize = 0;
            this.btn_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Xoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.Color.White;
            this.btn_Xoa.Location = new System.Drawing.Point(138, 6);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(120, 40);
            this.btn_Xoa.TabIndex = 2;
            this.btn_Xoa.Text = "Xóa sạch";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.TextChanged += new System.EventHandler(this.btn_Xoa_Click);
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_MauThu
            // 
            this.btn_MauThu.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_MauThu.ContextMenuStrip = this.ctx_SampleMenu;
            this.btn_MauThu.FlatAppearance.BorderSize = 0;
            this.btn_MauThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MauThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MauThu.ForeColor = System.Drawing.Color.White;
            this.btn_MauThu.Location = new System.Drawing.Point(270, 6);
            this.btn_MauThu.Margin = new System.Windows.Forms.Padding(6);
            this.btn_MauThu.Name = "btn_MauThu";
            this.btn_MauThu.Size = new System.Drawing.Size(120, 40);
            this.btn_MauThu.TabIndex = 3;
            this.btn_MauThu.Text = "Mẫu thử ";
            this.btn_MauThu.UseVisualStyleBackColor = false;
            this.btn_MauThu.TextChanged += new System.EventHandler(this.btn_MauThu_Click);
            this.btn_MauThu.Click += new System.EventHandler(this.btn_MauThu_Click);
            // 
            // ctx_SampleMenu
            // 
            this.ctx_SampleMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctx_SampleMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctx_SampleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mẫuĐúngToolStripMenuItem,
            this.lỗiSaiThứTựToolStripMenuItem,
            this.lỗiThiếuThẻToolStripMenuItem,
            this.bẫyToolStripMenuItem});
            this.ctx_SampleMenu.Name = "ctx_SampleMenu";
            this.ctx_SampleMenu.Size = new System.Drawing.Size(198, 140);
            // 
            // mẫuĐúngToolStripMenuItem
            // 
            this.mẫuĐúngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mẫuĐúngToolStripMenuItem.Name = "mẫuĐúngToolStripMenuItem";
            this.mẫuĐúngToolStripMenuItem.Size = new System.Drawing.Size(197, 34);
            this.mẫuĐúngToolStripMenuItem.Text = "Mẫu đúng";
            this.mẫuĐúngToolStripMenuItem.Click += new System.EventHandler(this.mẫuĐúngToolStripMenuItem_Click);
            // 
            // lỗiSaiThứTựToolStripMenuItem
            // 
            this.lỗiSaiThứTựToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lỗiSaiThứTựToolStripMenuItem.Name = "lỗiSaiThứTựToolStripMenuItem";
            this.lỗiSaiThứTựToolStripMenuItem.Size = new System.Drawing.Size(197, 34);
            this.lỗiSaiThứTựToolStripMenuItem.Text = "Lỗi sai thứ tự";
            this.lỗiSaiThứTựToolStripMenuItem.Click += new System.EventHandler(this.lỗiSaiThứTựToolStripMenuItem_Click_1);
            // 
            // lỗiThiếuThẻToolStripMenuItem
            // 
            this.lỗiThiếuThẻToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lỗiThiếuThẻToolStripMenuItem.Name = "lỗiThiếuThẻToolStripMenuItem";
            this.lỗiThiếuThẻToolStripMenuItem.Size = new System.Drawing.Size(197, 34);
            this.lỗiThiếuThẻToolStripMenuItem.Text = "Lỗi thiếu thẻ";
            this.lỗiThiếuThẻToolStripMenuItem.Click += new System.EventHandler(this.lỗiThiếuThẻToolStripMenuItem_Click);
            // 
            // bẫyToolStripMenuItem
            // 
            this.bẫyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bẫyToánTửNângCaoToolStripMenuItem,
            this.bẫyXuốngDòngToolStripMenuItem});
            this.bẫyToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bẫyToolStripMenuItem.Name = "bẫyToolStripMenuItem";
            this.bẫyToolStripMenuItem.Size = new System.Drawing.Size(197, 34);
            this.bẫyToolStripMenuItem.Text = "Bẫy";
            this.bẫyToolStripMenuItem.Click += new System.EventHandler(this.bẫyToolStripMenuItem_Click);
            // 
            // bẫyToánTửNângCaoToolStripMenuItem
            // 
            this.bẫyToánTửNângCaoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bẫyToánTửNângCaoToolStripMenuItem.Name = "bẫyToánTửNângCaoToolStripMenuItem";
            this.bẫyToánTửNângCaoToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.bẫyToánTửNângCaoToolStripMenuItem.Text = "Bẫy toán tử nâng cao";
            this.bẫyToánTửNângCaoToolStripMenuItem.Click += new System.EventHandler(this.bẫyToánTửNângCaoToolStripMenuItem_Click);
            // 
            // bẫyXuốngDòngToolStripMenuItem
            // 
            this.bẫyXuốngDòngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bẫyXuốngDòngToolStripMenuItem.Name = "bẫyXuốngDòngToolStripMenuItem";
            this.bẫyXuốngDòngToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.bẫyXuốngDòngToolStripMenuItem.Text = "Bẫy xuống dòng";
            this.bẫyXuốngDòngToolStripMenuItem.Click += new System.EventHandler(this.bẫyXuốngDòngToolStripMenuItem_Click);
            // 
            // rtb_LineNumbers
            // 
            this.rtb_LineNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtb_LineNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_LineNumbers.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtb_LineNumbers.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_LineNumbers.ForeColor = System.Drawing.Color.White;
            this.rtb_LineNumbers.Location = new System.Drawing.Point(3, 27);
            this.rtb_LineNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_LineNumbers.Name = "rtb_LineNumbers";
            this.rtb_LineNumbers.ReadOnly = true;
            this.rtb_LineNumbers.Size = new System.Drawing.Size(39, 356);
            this.rtb_LineNumbers.TabIndex = 4;
            this.rtb_LineNumbers.Text = "";
            this.rtb_LineNumbers.TextChanged += new System.EventHandler(this.rtb_LineNumbers_TextChanged);
            // 
            // rtb_InputHTML
            // 
            this.rtb_InputHTML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.rtb_InputHTML.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_InputHTML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_InputHTML.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_InputHTML.ForeColor = System.Drawing.Color.White;
            this.rtb_InputHTML.Location = new System.Drawing.Point(42, 27);
            this.rtb_InputHTML.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_InputHTML.Name = "rtb_InputHTML";
            this.rtb_InputHTML.Size = new System.Drawing.Size(380, 356);
            this.rtb_InputHTML.TabIndex = 5;
            this.rtb_InputHTML.Text = "";
            this.rtb_InputHTML.Click += new System.EventHandler(this.rtb_InputHTML_TextChanged);
            this.rtb_InputHTML.TextChanged += new System.EventHandler(this.rtb_InputHTML_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 386);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.rtb_OutputResult);
            this.tabPage1.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.Color.Gray;
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(838, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "KẾT QUẢ";
            // 
            // rtb_OutputResult
            // 
            this.rtb_OutputResult.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rtb_OutputResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_OutputResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_OutputResult.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_OutputResult.ForeColor = System.Drawing.Color.White;
            this.rtb_OutputResult.Location = new System.Drawing.Point(3, 4);
            this.rtb_OutputResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_OutputResult.Name = "rtb_OutputResult";
            this.rtb_OutputResult.ReadOnly = true;
            this.rtb_OutputResult.Size = new System.Drawing.Size(832, 340);
            this.rtb_OutputResult.TabIndex = 6;
            this.rtb_OutputResult.Text = "";
            this.rtb_OutputResult.TextChanged += new System.EventHandler(this.rtb_OutputResult_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage2.Controls.Add(this.tv_DOM);
            this.tabPage2.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.ForeColor = System.Drawing.Color.Gray;
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(838, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DOMTREE";
            // 
            // tv_DOM
            // 
            this.tv_DOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tv_DOM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_DOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_DOM.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_DOM.ForeColor = System.Drawing.Color.Gainsboro;
            this.tv_DOM.Location = new System.Drawing.Point(3, 4);
            this.tv_DOM.Margin = new System.Windows.Forms.Padding(0);
            this.tv_DOM.Name = "tv_DOM";
            this.tv_DOM.Size = new System.Drawing.Size(832, 340);
            this.tv_DOM.TabIndex = 0;
            // 
            // rtb_Trace
            // 
            this.rtb_Trace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtb_Trace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Trace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Trace.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_Trace.ForeColor = System.Drawing.Color.LightBlue;
            this.rtb_Trace.Location = new System.Drawing.Point(3, 27);
            this.rtb_Trace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_Trace.Name = "rtb_Trace";
            this.rtb_Trace.ReadOnly = true;
            this.rtb_Trace.Size = new System.Drawing.Size(419, 276);
            this.rtb_Trace.TabIndex = 11;
            this.rtb_Trace.Text = "";
            this.rtb_Trace.TextChanged += new System.EventHandler(this.rtb_Trace_TextChanged);
            // 
            // lv_Queue
            // 
            this.lv_Queue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lv_Queue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_Queue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Queue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_Queue.ForeColor = System.Drawing.SystemColors.Window;
            this.lv_Queue.FullRowSelect = true;
            this.lv_Queue.GridLines = true;
            this.lv_Queue.HideSelection = false;
            this.lv_Queue.Location = new System.Drawing.Point(0, 0);
            this.lv_Queue.Name = "lv_Queue";
            this.lv_Queue.Size = new System.Drawing.Size(280, 229);
            this.lv_Queue.TabIndex = 16;
            this.lv_Queue.UseCompatibleStateImageBehavior = false;
            this.lv_Queue.View = System.Windows.Forms.View.Details;
            this.lv_Queue.SelectedIndexChanged += new System.EventHandler(this.lv_Queue_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Thẻ trong hàng đợi";
            this.columnHeader1.Width = 202;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dòng";
            this.columnHeader2.Width = 325;
            // 
            // lv_Stack
            // 
            this.lv_Stack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lv_Stack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lv_Stack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Stack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_Stack.ForeColor = System.Drawing.SystemColors.Window;
            this.lv_Stack.HideSelection = false;
            this.lv_Stack.Location = new System.Drawing.Point(0, 0);
            this.lv_Stack.Name = "lv_Stack";
            this.lv_Stack.Size = new System.Drawing.Size(556, 229);
            this.lv_Stack.TabIndex = 17;
            this.lv_Stack.UseCompatibleStateImageBehavior = false;
            this.lv_Stack.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngăn xếp (Stack)";
            this.columnHeader3.Width = 170;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 306);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TRẠNG THÁI THUẬT TOÁN";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 74);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lv_Queue);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lv_Stack);
            this.splitContainer2.Size = new System.Drawing.Size(840, 229);
            this.splitContainer2.SplitterDistance = 280;
            this.splitContainer2.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_Step);
            this.flowLayoutPanel1.Controls.Add(this.btn_RunAll);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(840, 47);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // btn_Step
            // 
            this.btn_Step.AutoSize = true;
            this.btn_Step.BackColor = System.Drawing.Color.Orange;
            this.btn_Step.FlatAppearance.BorderSize = 0;
            this.btn_Step.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Step.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Step.Location = new System.Drawing.Point(3, 3);
            this.btn_Step.Name = "btn_Step";
            this.btn_Step.Size = new System.Drawing.Size(124, 40);
            this.btn_Step.TabIndex = 14;
            this.btn_Step.Text = "Bước tiếp";
            this.btn_Step.UseVisualStyleBackColor = false;
            this.btn_Step.Click += new System.EventHandler(this.btn_Step_Click_1);
            // 
            // btn_RunAll
            // 
            this.btn_RunAll.AutoSize = true;
            this.btn_RunAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_RunAll.FlatAppearance.BorderSize = 0;
            this.btn_RunAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RunAll.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RunAll.Location = new System.Drawing.Point(133, 3);
            this.btn_RunAll.Name = "btn_RunAll";
            this.btn_RunAll.Size = new System.Drawing.Size(120, 40);
            this.btn_RunAll.TabIndex = 15;
            this.btn_RunAll.Text = "Chạy hết";
            this.btn_RunAll.UseVisualStyleBackColor = false;
            this.btn_RunAll.Click += new System.EventHandler(this.btn_RunAll_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel2.Controls.Add(this.btn_PhanTich);
            this.flowLayoutPanel2.Controls.Add(this.btn_Xoa);
            this.flowLayoutPanel2.Controls.Add(this.btn_MauThu);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 32);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1324, 47);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(15, 85);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint_1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1275, 386);
            this.splitContainer1.SplitterDistance = 425;
            this.splitContainer1.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtb_InputHTML);
            this.groupBox3.Controls.Add(this.rtb_LineNumbers);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 386);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NHẬP MÃ HTML";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(15, 478);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer3.Size = new System.Drawing.Size(1275, 306);
            this.splitContainer3.SplitterDistance = 425;
            this.splitContainer3.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_Trace);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 306);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TRUY VẾT THUẬT TOÁN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1302, 805);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1109, 861);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTML Queue Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ctx_SampleMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_MoFile;
        private System.Windows.Forms.ToolStripMenuItem menu_LuuFile;
        private System.Windows.Forms.ToolStripMenuItem menu_Thoat;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_HuongDan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menu_TacGia;
        private System.Windows.Forms.Button btn_PhanTich;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_MauThu;
        private System.Windows.Forms.ContextMenuStrip ctx_SampleMenu;
        private System.Windows.Forms.ToolStripMenuItem mẫuĐúngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lỗiSaiThứTựToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lỗiThiếuThẻToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtb_LineNumbers;
        private System.Windows.Forms.RichTextBox rtb_InputHTML;
        private System.Windows.Forms.ToolStripMenuItem bẫyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bẫyToánTửNângCaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bẫyXuốngDòngToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView tv_DOM;
        private System.Windows.Forms.RichTextBox rtb_Trace;
        private System.Windows.Forms.ListView lv_Queue;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lv_Stack;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_RunAll;
        private System.Windows.Forms.Button btn_Step;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtb_OutputResult;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}