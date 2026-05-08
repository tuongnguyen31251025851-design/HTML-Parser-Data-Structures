using System;
using System.Windows.Forms;

namespace HTMLParseProject_V1
{
    static class Program
    {
        /// <summary>
        /// Điểm khởi đầu chính của ứng dụng.
        /// </summary>
        [STAThread] // Định nghĩa rằng ứng dụng sử dụng mô hình đơn luồng giao diện người dùng (Single Thread Apartment)
        static void Main()
        {
            // Thiết lập giao diện người dùng và chạy ứng dụng
            Application.EnableVisualStyles();
            // Thiết lập chế độ kết xuất văn bản tương thích (để đảm bảo rằng các điều khiển hiển thị văn bản đúng cách)
            Application.SetCompatibleTextRenderingDefault(false);

            // QUAN TRỌNG: Khởi tạo và chạy Form chính
            // Nếu đổi tên class Form1, hãy đảm bảo cập nhật tên class ở đây để tránh lỗi khi chạy ứng dụng
            Application.Run(new Form1());
        }
    }
}