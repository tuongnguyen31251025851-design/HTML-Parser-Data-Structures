# HTML-Parser-Data-Structures
Đồ án môn Cấu trúc dữ liệu và Giải thuật - Đề tài số 1. Xây dựng bộ đọc HTML sử dụng Queue.
HTML Parser Project - Data Structures & Algorithms
📝 Giới thiệu đề tài
Đồ án môn Cấu trúc dữ liệu và Giải thuật tại trường Đại học Kinh tế TP.HCM (UEH).
Dự án tập trung vào việc xây dựng một bộ đọc (Parser) nội dung HTML, sử dụng các cấu trúc dữ liệu tự cài đặt để xử lý và phân tích cú pháp.
Giảng viên hướng dẫn: TS. Đặng Ngọc Hoàng Thành

🚀 Tính năng chính
Phân tích cú pháp HTML: Trích xuất văn bản sạch từ các thẻ HTML.
Dựng cây DOM (Document Object Model): Biểu diễn cấu trúc phân cấp của trang web.
Kiểm tra tính hợp lệ: Phát hiện các thẻ đóng/mở sai quy cách bằng Stack.

🛠 Cấu trúc dữ liệu sử dụng
Dự án ưu tiên việc tự cài đặt (implement) các cấu trúc dữ liệu cốt lõi thay vì dùng thư viện có sẵn để tối ưu hóa việc học tập:
Stack (Ngăn xếp): Dùng để đối soát các cặp thẻ HTML (Matching tags).
Queue (Hàng đợi): Dùng để quản lý luồng dữ liệu văn bản sau khi bóc tách.
Tree (Cây): Dùng để lưu trữ cấu trúc phân cấp DOM.
Dictionary: Dùng để tra cứu nhanh danh sách các thẻ tự đóng (Self-closing tags).

📁 Cấu trúc thư mục
├── Structure/          # Các cấu trúc dữ liệu tự cài đặt (Stack, Queue, Tree,...)
├── Forms/              # Giao diện người dùng (WinForms)
├── README.md           # Hướng dẫn dự án
└── HTMLParseProject.sln # File thực thi chính của dự án

💻 Hướng dẫn chạy thử
Tải toàn bộ mã nguồn về máy hoặc dùng lệnh git clone
Mở file .sln bằng Visual Studio.
Nhấn F5 hoặc nút Start để biên dịch và chạy giao diện.
Nhập đoạn mã HTML mẫu vào ô input và nhấn "Execute".

📊 Mã nguồn kiểm thử nhanh
Dùng đoạn mã này để test tính năng của chương trình:
<div>
    <h3>Chào mừng đến với UEH!</h3>
    <p>Học về <b>Cấu trúc dữ liệu</b> rất thú vị.</p>
    <img src="logo.png" />
    <br>
</div>
