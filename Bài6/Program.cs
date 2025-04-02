Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Write("Nhập một số: ");
double so = double.Parse(Console.ReadLine() ?? "0");

// Kiểm tra số dương, âm hay bằng 0
if (so > 0)
{
    Console.WriteLine($"{so} là số dương.");
}
else if (so < 0)
{
    Console.WriteLine($"{so} là số âm.");
}
else
{
    Console.WriteLine("Số bạn nhập là 0.");
}