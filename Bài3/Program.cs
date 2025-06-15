Console.OutputEncoding = System.Text.Encoding.UTF8;
// Nhập nhiệt độ C từ bàn phím
Console.Write("Nhập nhiệt độ (độ C): ");
double doC = double.Parse(Console.ReadLine() ?? "0");

// Chuyển đổi sang độ F
double doF = (doC * 9 / 5) + 32;

// Hiển thị kết quả
Console.WriteLine($"{doC} độ C tương đương {doF} độ F");