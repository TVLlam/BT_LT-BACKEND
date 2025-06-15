using System;
using System.Collections.Generic;

class PhanSo
{
    public int TuSo { get; set; }
    public int MauSo { get; set; }

    public PhanSo()
    {
        TuSo = 0;
        MauSo = 1;
    }

    public PhanSo(int tu, int mau)
    {
        if (mau == 0)
            throw new ArgumentException("Mẫu số không được bằng 0");
        TuSo = tu;
        MauSo = mau;
        RutGon();
    }

    public void Nhap()
    {
        Console.Write("Nhập tử số: ");
        TuSo = int.Parse(Console.ReadLine());

        do
        {
            Console.Write("Nhập mẫu số (khác 0): ");
            MauSo = int.Parse(Console.ReadLine());
        } while (MauSo == 0);

        RutGon();
    }

    // Hàm rút gọn phân số
    private void RutGon()
    {
        int ucln = UCLN(Math.Abs(TuSo), Math.Abs(MauSo));
        TuSo /= ucln;
        MauSo /= ucln;
        if (MauSo < 0) // Đưa dấu âm về tử số
        {
            TuSo *= -1;
            MauSo *= -1;
        }
    }

    private int UCLN(int a, int b)
    {
        return b == 0 ? a : UCLN(b, a % b);
    }

    public static PhanSo operator +(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
        int mau = a.MauSo * b.MauSo;
        return new PhanSo(tu, mau);
    }

    public override string ToString()
    {
        return $"{TuSo}/{MauSo}";
    }
}

class Program
{
    static void Main()
    {
       
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        List<PhanSo> danhSach = new List<PhanSo>();
        Console.Write("Nhập số lượng phân số: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Phân số thứ {i + 1}:");
            PhanSo ps = new PhanSo();
            ps.Nhap();
            danhSach.Add(ps);
        }

        PhanSo tong = new PhanSo(0, 1);
        foreach (var ps in danhSach)
        {
            tong += ps;
        }

        Console.WriteLine($"\nTổng các phân số là: {tong}");
    }
}
