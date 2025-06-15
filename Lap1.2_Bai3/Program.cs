using System;
using System.Text;

class Program
{
    // Hàm đếm số âm và số dương
    static void DemSoAmVaDuong(int[] mang, out int soAm, out int soDuong)
    {
        soAm = 0;
        soDuong = 0;

        foreach (int so in mang)
        {
            if (so < 0)
                soAm++;
            else if (so > 0)
                soDuong++;
        }
    }

    static void Main()
    {
   
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập số lượng phần tử của mảng: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        int[] mang = new int[n];

        // Nhập mảng từ bàn phím
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhập phần tử thứ {i}: ");
            mang[i] = int.Parse(Console.ReadLine() ?? "0");
        }

        // Gọi hàm để đếm
        DemSoAmVaDuong(mang, out int demAm, out int demDuong);

        Console.WriteLine($"\nSố lượng phần tử âm: {demAm}");
        Console.WriteLine($"Số lượng phần tử dương: {demDuong}");
    }
}
