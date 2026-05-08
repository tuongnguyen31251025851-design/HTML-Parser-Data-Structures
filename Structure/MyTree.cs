using System.Collections.Generic;

namespace HTMLParseProject_V1
{
    //Lớp đại diện cho một node trong cây HTML, chứa tên thẻ, nội dung và danh sách con
    // Giúp mô phỏng lại mô hình DOM (Document Object Model) của HTML
    public class HTMLNode
    {        
        public string TagName; // Tên thẻ HTML (ví dụ: "div", "p", "h1")
        public string Content; // Nội dung bên trong thẻ (ví dụ: "Hello World" trong <p>Hello World</p>)

        // Sử dụng mảng cố định để lưu trữ các node con
        public HTMLNode[] Children;
        public int ChildCount;
        public bool IsError = false;

        // Constructor khởi tạo một node HTML với tên thẻ và mảng con
        public HTMLNode(string name)
        {
            TagName = name;
            Children = new HTMLNode[100]; // Khởi tạo mảng con với kích thước tối đa 100
            ChildCount = 0;      
        }

        // Phương thức thêm một node con vào node hiện tại
        public void AddChild(HTMLNode child)
        {
            if (ChildCount < 100)
            {
                // Thêm vào vị trí tiếp theo trong mảng và tăng số lượng biến đếm 
                Children[ChildCount++] = child;
            }
        }
    }
}






