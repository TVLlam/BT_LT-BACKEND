using System;
using System.Text;

class Program
{
    // Hàm kiểm tra số nguyên tố
    static bool LaSoNguyenTo(int n)
    {
        if (n < 2)
            return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    static void Main()
    {

        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Nhập số lượng phần tử của mảng: ");
        int n = int.Parse(Console.ReadLine() ??"0");

        int[] mang = new int[n];

        // Nhập mảng từ bàn phím
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhập phần tử thứ {i}: ");
            mang[i] = int.Parse(Console.ReadLine() ?? "0");
        }

        Console.WriteLine("\nCác phần tử là số nguyên tố trong mảng:");
        for (int i = 0; i < n; i++)
        {
            if (LaSoNguyenTo(mang[i]))
            {
                Console.WriteLine($"Chỉ số {i} - Giá trị {mang[i]}");
            }
        }
    }
}
