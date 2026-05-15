# HTML-Parser-Data-Structures

Đồ án môn **Cấu trúc dữ liệu và Giải thuật** - Đề tài số 1: Xây dựng bộ đọc HTML sử dụng Queue, Stack và Tree.

---

### 🚀 Giới thiệu đề tài
Dự án tập trung vào việc xây dựng một bộ đọc (Parser) nội dung HTML tại trường **Đại học Kinh tế TP.HCM (UEH)**. Chương trình sử dụng các cấu trúc dữ liệu tự cài đặt để xử lý và phân tích cú pháp một cách tối ưu.

* **Giảng viên hướng dẫn:** TS. Đặng Ngọc Hoàng Thành

---

### ✨ Tính năng chính
* **Phân tích cú pháp HTML:** Trích xuất văn bản sạch từ các thẻ HTML.
* **Dựng cây DOM:** Biểu diễn cấu trúc phân cấp của trang web.
* **Kiểm tra tính hợp lệ:** Phát hiện các thẻ đóng/mở sai quy cách bằng Stack.

---

### 🛠 Cấu trúc dữ liệu sử dụng
Dự án ưu tiên việc tự cài đặt các cấu trúc dữ liệu cốt lõi:
* **Stack (Ngăn xếp):** Dùng để đối soát các cặp thẻ HTML (Matching tags).
* **Queue (Hàng đợi):** Dùng để quản lý luồng dữ liệu văn bản sau khi bóc tách.
* **Tree (Cây):** Dùng để lưu trữ cấu trúc phân cấp DOM.
* **Dictionary:** Dùng để tra cứu nhanh danh sách các thẻ tự đóng.

---

### 📂 Cấu trúc thư mục
```text
├── Structure/          # Các cấu trúc dữ liệu tự cài đặt
├── Forms/              # Giao diện người dùng (WinForms)
├── README.md           # Hướng dẫn dự án
└── HTMLParseProject.sln # File thực thi chính

---

| Thành Viên | Mã Số Sinh Viên | Nhiệm Vụ |
| :--- | :---: | :--- |
| **Nguyễn Ngọc Cát Tường** | 31251025851 | • Cài đặt chương trình<br>• Thiết kế giao diện Chức năng Chạy từng bước & Chạy toàn bộ, Chức năng bổ trợ |
| **Nguyễn Quốc Lộc** | 31251021469 | • Viết báo cáo chương 1<br>• Tổng hợp báo cáo<br>• Thiết kế giao diện Chức năng Nhập liệu, Phân tích mẫu và Xóa<br>• Viết báo cáo chương 2<br>• Thuyết trình |
| **Nguyễn Minh Hiếu** | 31251024563 | • Viết báo cáo chương 3<br>• Thiết kế giao diện Chức năng Hiển thị kết quả và cây DOM<br>• Lên ý tưởng làm slide thuyết trình<br>• Làm slide thuyết trình Chương 1, Chương 2, Tổng kết |
| **Phạm Thạch Tùng** | 31251028044 | • Viết báo cáo chương 4<br>• Thiết kế giao diện Chức năng Truy vết và Thông báo lỗi<br>• Viết lời mở đầu<br>• Làm slide thuyết trình Chương 3, Chương 4 |
| **Nguyễn Quốc Lộc** | 31251021469 | • Viết báo cáo chương 1<br>• Tổng hợp báo cáo<br>• Thiết kế giao diện Chức năng Nhập liệu, Phân tích mẫu và Xóa<br>• Viết báo cáo chương 2<br>• Thuyết trình |
| **Nguyễn Minh Hiếu** | 31251024563 | • Viết báo cáo chương 3<br>• Thiết kế giao diện Chức năng Hiển thị kết quả và cây DOM<br>• Lên ý tưởng làm slide thuyết trình<br>• Làm slide thuyết trình Chương 1, Chương 2, Tổng kết |
| **Phạm Thạch Tùng** | 31251028044 | • Viết báo cáo chương 4<br>• Thiết kế giao diện Chức năng Truy vết và Thông báo lỗi<br>• Viết lời mở đầu<br>• Làm slide thuyết trình Chương 3, Chương 4 |
