Console.OutputEncoding = System.Text.Encoding.UTF8;
// In ra tiêu đề bảng cửu chương
Console.WriteLine("Bảng cửu chương từ 1 đến 10:");

// Duyệt qua các bảng từ 1 đến 10
for (int i = 1; i <= 10; i++)
{
    // In ra bảng cửu chương của i
    for (int j = 1; j <= 10; j++)
    {
        // In ra mỗi phép tính trong bảng cửu chương
        Console.Write($"{i * j}\t");
    }
    // Xuống dòng sau mỗi bảng
    Console.WriteLine();
}