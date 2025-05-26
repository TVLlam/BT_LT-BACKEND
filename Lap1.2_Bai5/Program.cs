using System;
using System.Text;

class Program
{
    // Hàm hoán vị 2 số nguyên sử dụng tham chiếu (ref)
    static void HoanVi(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Nhập 2 số nguyên từ bàn phím
        Console.Write("Nhập số nguyên a: ");
        int a = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Nhập số nguyên b: ");
        int b = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine($"\nTrước khi hoán vị: a = {a}, b = {b}");

        // Gọi hàm hoán vị
        HoanVi(ref a, ref b);

        Console.WriteLine($"Sau khi hoán vị: a = {a}, b = {b}");
    }
}
