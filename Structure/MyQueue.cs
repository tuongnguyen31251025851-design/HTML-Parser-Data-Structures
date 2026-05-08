using System;
using System.Drawing;

namespace HTMLParseProject_V1
{
    // Cấu trúc dữ liệu hàng đợi (Queue) tự xây dựng bằng mảng vòng (Circular Array-based Queue)
    // Nguyên lý: FIFO (First In First Out) - phần tử được thêm vào đầu tiên sẽ được lấy ra đầu tiên.
    public class MyQueue
    {
        private object[] items; // Mảng lưu trữ các phần tử trong hàng đợi
        private int head; // Vị trí lấy ra
        private int tail; // Vị trí thêm vào
        private int count; // Biến đếm số lượng phần tử hiện có trong hàng đợi
        private const int MAX_SIZE = 1000;

        // Khởi tạo hàng đợi
        public MyQueue()
        {
            items = new object[MAX_SIZE];
            head = 0;
            tail = -1;
            count = 0;
        }

        // Thêm một phần tử vào cuối hàng đợi
        public void Enqueue(object item)
        {
            if (count < MAX_SIZE)
            {
                // Kỹ thuật mảng vòng: Dùng toán tử % để quay lại đầu mảng nếu vượt quá MAX_SIZE
                tail = (tail + 1) % MAX_SIZE;
                items[tail] = item;
                count++;
            }
        }

        // Lấy ra phần tử ở đầu hàng đợi ra và xử lý
        public object Dequeue()
        {
            if (IsEmpty()) return null;
            object item = items[head];
            // Tịnh tiến head lên vị trí tiếp theo, cũng sử dụng kỹ thuật mảng vòng
            head = (head + 1) % MAX_SIZE;
            count--;
            return item;
        }

        // Phương thức chuyển đổi hàng đợi thành mảng để dễ dàng hiển thị hoặc xử lý
        public object[] ToArray()
        {
            object[] arr = new object[count];
            for (int i = 0; i < count; i++)
            {
                // Lấy phần tử theo logic hàng đợi, bắt đầu từ head
                arr[i] = items[(head + i) % MAX_SIZE];
            }
            return arr;
        }

        // Kiểm tra xem hàng đợi có rỗng hay không dựa vào biến đếm count
        public bool IsEmpty() => count == 0;
    }
}

