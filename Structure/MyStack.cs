using System;

namespace HTMLParseProject_V1
{
    // Cấu trúc dữ liệu ngăn xếp (Stack) tự xây dựng bằng mảng (Array-based Stack)
    // Nguyên lý: LIFO (Last In First Out) - phần tử được thêm vào cuối cùng sẽ được lấy ra đầu tiên.
   
    public class MyStack
    {
        // Phương thức xem phần tử ở đỉnh ngăn xếp mà không loại bỏ nó
        public object Peek()
        {
            if (IsEmpty()) return null;            
            return items[top];
        }
        private object[] items; //Mảng lưu trữ các phần tử trong ngăn xếp
        private int top; //Biến quản lý vị trí đỉnh của ngăn xếp
        private const int MAX_SIZE = 1000; //Giới hạn kích thước của ngăn xếp để tránh tràn bộ nhớ

        // Khởi tạo ngăn xếp
        public MyStack()
        {
            items = new object[MAX_SIZE];
            top = -1; // Khởi tạo Stack trống 
        }

        // Thêm một phần tử vào đỉnh ngăn xếp
        public void Push(object item)
        {
            if (top < MAX_SIZE - 1)
                // Tăng chỉ số top trước, sau đó mới gán giá trị vào mảng
                items[++top] = item;
        }

        //Lấy ra phần tử ở đỉnh ngăn xếp ra khỏi nó và xóa
        public object Pop()
        {
            if (IsEmpty()) return null;
            //Trả về giá trị tại vị trí top, sau đó mới giảm chỉ số top
            return items[top--];
        }

        //Kiểm tra xem ngăn xếp có rỗng hay không
        public bool IsEmpty()
        {
            return top == -1;
        }

        // Phương thức chuyển đổi ngăn xếp thành mảng để dễ dàng hiển thị hoặc xử lý
        public object[] ToArray() 
        {
            int count = top + 1; // Calculate the number of items
            object[] arr = new object[count];
            for (int i = 0; i <= top; i++)
            {
                arr[i] = items[i];
            }
            return arr;
        }
    }
}