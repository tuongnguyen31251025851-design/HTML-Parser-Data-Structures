public class MyDictionary
{
    // Danh sách các thẻ HTML chuẩn (viết thường, không khoảng trắng)
    private string[] validTags = {
        "form","html", "body", "head", "title", "div", "p",
        "h1", "h2", "h3", "span", "b", "i", "u",
        "table", "tr", "td", "th", "ul", "li", "section", "aside", "img", "br", "hr", "input", "meta", "link", "label", "footer"
    };

    // Hàm kiểm tra xem một chuỗi có phải là tên thẻ HTML hợp lệ hay không
    public bool IsTagValid(string tag)
    {
        // Kiểm tra cơ bản: Nếu chuỗi rỗng hoặc null thì chắc chắn không phải là thẻ hợp lệ
        if (string.IsNullOrEmpty(tag)) return false;

        // Xử lý bẫy quan trọng: Một thẻ HTML chuẩn không được chứa khoảng trắng ở giữa tên thẻ
        // Ví dụ: <b> hoặc < b> có thể được chấp nhận tùy Lexer
        // nhưng "b " (có cấu cách sau chữ b) thường là kết quả của nhầm lẫn dấu so sánh <
        if (tag.Contains(" ")) return false;

        // Chuẩn hóa tên thẻ về chữ thường để so sánh chính xác (không phân biệt hoa, thường)
        string cleanTag = tag.ToLower().Trim();

        // Duyệt qua danh sách validTags để đối soát
        foreach (string t in validTags)
        {
            if (t == cleanTag) return true;
        }
        return false; //Không nằm trong danh sách các thẻ được hỗ trợ
    }
}
