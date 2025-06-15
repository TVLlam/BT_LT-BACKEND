Console.OutputEncoding = System.Text.Encoding.UTF8;
// Nhập năm từ người dùng
Console.Write("Nhập năm: ");
int nam = int.Parse(Console.ReadLine() ?? "0");

// Kiểm tra năm nhuận
if (IsLeapYear(nam))
{
    Console.WriteLine($"{nam} là năm nhuận.");
}
else
{
    Console.WriteLine($"{nam} không phải là năm nhuận.");
}

    // Hàm kiểm tra năm nhuận
    static bool IsLeapYear(int year)
{
    // Kiểm tra năm chia hết cho 4 nhưng không chia hết cho 100
    return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}