Console.OutputEncoding = System.Text.Encoding.UTF8;
// Nhập số nguyên từ bàn phím
Console.Write("Nhập một số nguyên: ");
int so = int.Parse(Console.ReadLine() ?? "0");

// Kiểm tra số chẵn hay lẻ
if (so % 2 == 0)
{
    Console.WriteLine($"{so} là số chẵn.");
}
else
{
    Console.WriteLine($"{so} là số lẻ.");
}