using System;
using System.Text;

class Program
{
    // Hàm sắp xếp mảng số thực theo thứ tự tăng dần (dùng thuật toán nổi bọt - Bubble Sort)
    static void SapXepTangDan(double[] mang)
    {
        int n = mang.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (mang[j] > mang[j + 1])
                {
                    // Hoán đổi 2 phần tử
                    double temp = mang[j];
                    mang[j] = mang[j + 1];
                    mang[j + 1] = temp;
                }
            }
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập số lượng phần tử: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        double[] mang = new double[n];

        // Nhập mảng từ bàn phím
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhập phần tử thứ {i}: ");
            mang[i] = double.Parse(Console.ReadLine() ?? "0");
        }

        // Gọi hàm sắp xếp
        SapXepTangDan(mang);

        // In mảng sau khi sắp xếp
        Console.WriteLine("\nMảng sau khi sắp xếp tăng dần:");
        foreach (double so in mang)
        {
            Console.Write(so + " ");
        }
    }
}
