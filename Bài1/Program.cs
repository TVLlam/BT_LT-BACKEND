Console.OutputEncoding = System.Text.Encoding.UTF8;
// Nhập tên từ bàn phím
Console.Write("Nhập tên của bạn: ");
string ten = Console.ReadLine() ?? "0";

// Nhập tuổi từ bàn phím
Console.Write("Nhập tuổi của bạn: ");
int tuoi = int.Parse(Console.ReadLine() ?? "0");

// Hiển thị thông báo
Console.WriteLine($"Xin chào {ten}, bạn {tuoi} tuổi!");