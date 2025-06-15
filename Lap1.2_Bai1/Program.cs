using System;
using System.Text;
class Program
{
    // Hàm tính tổng các số chẵn trong mảng
    static int TinhTongSoChan(int[] mang)
    {
        int tong = 0;
        foreach (int so in mang)
        {
            if (so % 2 == 0)
            {
                tong += so;
            }
        }
        return tong;
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int[] mangSoNguyen = { 1, 3, 4, 5, 6, 8, 11 };

        int tongChan = TinhTongSoChan(mangSoNguyen);

        Console.WriteLine("Tổng các số chẵn trong mảng là: " + tongChan);
    }
}
