Console.OutputEncoding = System.Text.Encoding.UTF8;
// Khai báo biến cho chiều dài và chiều rộng
double length, width, area;

// Nhập chiều dài
Console.Write("Nhập chiều dài của hình chữ nhật: ");
length = Convert.ToDouble(Console.ReadLine());

// Nhập chiều rộng
Console.Write("Nhập chiều rộng của hình chữ nhật: ");
width = Convert.ToDouble(Console.ReadLine());

// Tính diện tích
area = length * width;

// Hiển thị kết quả
Console.WriteLine($"Diện tích của hình chữ nhật là: {area}");
