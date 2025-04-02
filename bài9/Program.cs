Console.OutputEncoding = System.Text.Encoding.UTF8;
// Nhập số nguyên dương n từ người dùng
Console.Write("Nhập số nguyên dương n: ");
int n = int.Parse(Console.ReadLine() ?? "0" );

// Kiểm tra xem n có phải là số nguyên dương không
if (n < 0)
{
    Console.WriteLine("Vui lòng nhập một số nguyên dương!");
}
else
{
    // Tính giai thừa và in kết quả
    long result = GiaiThua(n);
    Console.WriteLine($"Giai thừa của {n} là: {result}");
}

    // Hàm tính giai thừa
    static long GiaiThua(int n)
{
    long result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    return result;
}