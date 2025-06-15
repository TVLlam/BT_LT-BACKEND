Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Write("Nhập số thứ nhất: ");
double so1 = double.Parse(Console.ReadLine() ?? "0");

Console.Write("Nhập số thứ hai: ");
double so2 = double.Parse(Console.ReadLine() ?? "0");

// Tính tổng và tích
double tong = so1 + so2;
double tich = so1 * so2;

Console.WriteLine($"Tổng của {so1} và {so2} là: {tong}");
Console.WriteLine($"Tích của {so1} và {so2} là: {tich}");