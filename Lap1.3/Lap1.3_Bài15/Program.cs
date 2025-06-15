using System;
using System.Collections.Generic;

// 1. Lớp DaGiac
public class DaGiac
{
    protected int soCanh;
    protected int[] cacCanh;

    public DaGiac()
    {
        soCanh = 0;
        cacCanh = new int[0];
    }

    public DaGiac(int soCanh, int[] cacCanh)
    {
        this.soCanh = soCanh;
        this.cacCanh = new int[soCanh];
        Array.Copy(cacCanh, this.cacCanh, soCanh);
    }

    public virtual void NhapDaGiac()
    {
        Console.Write("Nhập số cạnh của đa giác: ");
        soCanh = int.Parse(Console.ReadLine());
        cacCanh = new int[soCanh];

        for (int i = 0; i < soCanh; i++)
        {
            Console.Write($"Nhập độ dài cạnh thứ {i + 1}: ");
            cacCanh[i] = int.Parse(Console.ReadLine());
        }
    }

    public virtual int TinhChuVi()
    {
        int chuVi = 0;
        foreach (int canh in cacCanh)
        {
            chuVi += canh;
        }
        return chuVi;
    }

    public void InCacCanh()
    {
        Console.Write("Các cạnh của đa giác: ");
        for (int i = 0; i < soCanh; i++)
        {
            Console.Write(cacCanh[i] + " ");
        }
        Console.WriteLine();
    }
}

// 2. Lớp TamGiac kế thừa từ DaGiac
public class TamGiac : DaGiac
{
    public TamGiac() : base()
    {
        soCanh = 3;
        cacCanh = new int[3];
    }

    public TamGiac(int a, int b, int c) : base(3, new int[] { a, b, c })
    {
    }

    public override void NhapDaGiac()
    {
        soCanh = 3;
        cacCanh = new int[3];

        Console.WriteLine("Nhập độ dài 3 cạnh tam giác:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Nhập cạnh thứ {i + 1}: ");
            cacCanh[i] = int.Parse(Console.ReadLine());
        }

        // Kiểm tra điều kiện tam giác
        while (!LaTamGiacHopLe())
        {
            Console.WriteLine("Ba cạnh không tạo thành tam giác hợp lệ! Vui lòng nhập lại.");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Nhập cạnh thứ {i + 1}: ");
                cacCanh[i] = int.Parse(Console.ReadLine());
            }
        }
    }

    private bool LaTamGiacHopLe()
    {
        return (cacCanh[0] + cacCanh[1] > cacCanh[2]) &&
               (cacCanh[0] + cacCanh[2] > cacCanh[1]) &&
               (cacCanh[1] + cacCanh[2] > cacCanh[0]);
    }

    public override int TinhChuVi()
    {
        return base.TinhChuVi();
    }

    public double TinhDienTich()
    {
        // Sử dụng công thức Heron
        double p = TinhChuVi() / 2.0;
        return Math.Sqrt(p * (p - cacCanh[0]) * (p - cacCanh[1]) * (p - cacCanh[2]));
    }

    public bool LaTamGiacVuong()
    {
        // Kiểm tra định lý Pythagore
        int a = cacCanh[0], b = cacCanh[1], c = cacCanh[2];

        return (a * a + b * b == c * c) ||
               (a * a + c * c == b * b) ||
               (b * b + c * c == a * a);
    }
}

// 3. Ứng dụng chính
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Nhập số lượng tam giác
        Console.Write("Nhập số lượng tam giác: ");
        int n = int.Parse(Console.ReadLine());

        List<TamGiac> danhSachTamGiac = new List<TamGiac>();

        // Nhập thông tin các tam giác
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập thông tin tam giác thứ {i + 1}:");
            TamGiac tg = new TamGiac();
            tg.NhapDaGiac();
            danhSachTamGiac.Add(tg);
        }

        // Hiển thị các tam giác thỏa mãn định lý Pitago
        Console.WriteLine("\nCác tam giác vuông (thỏa mãn định lý Pitago):");
        int dem = 0;

        foreach (TamGiac tg in danhSachTamGiac)
        {
            if (tg.LaTamGiacVuong())
            {
                dem++;
                Console.WriteLine($"\nTam giác {dem}:");
                tg.InCacCanh();
                Console.WriteLine($"Chu vi: {tg.TinhChuVi()}");
                Console.WriteLine($"Diện tích: {tg.TinhDienTich():F2}");
            }
        }

        if (dem == 0)
        {
            Console.WriteLine("Không có tam giác nào thỏa mãn định lý Pitago!");
        }
    }
}