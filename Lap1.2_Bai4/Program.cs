using System;
using System.Text;
class Program
{
    static int TimSoLonThuHai(int[] mang)
    {
        if (mang.Length < 2)
            throw new ArgumentException("Mảng phải có ít nhất 2 phần tử.");

        int max1 = int.MinValue;
        int max2 = int.MinValue;

        foreach (int so in mang)
        {
            if (so > max1)
            {
                max2 = max1;
                max1 = so;
            }
            else if (so > max2 && so < max1)
            {
                max2 = so;
            }
        }

        if (max2 == int.MinValue)
            throw new Exception("Không tồn tại số lớn thứ hai trong mảng.");

        return max2;
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập số lượng phần tử: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        int[] mang = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhập phần tử thứ {i}: ");
            mang[i] = int.Parse(Console.ReadLine() ?? "0");
        }

        try
        {
            int soLonThuHai = TimSoLonThuHai(mang);
            Console.WriteLine($"Số lớn thứ hai trong mảng là: {soLonThuHai}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }
}
