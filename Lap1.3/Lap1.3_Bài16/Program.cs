using System;
using System.Collections.Generic;

// 1. Lớp Diem
public class Diem
{
    public double X { get; set; }
    public double Y { get; set; }

    // Toán tử tạo lập
    public Diem()
    {
        X = 0;
        Y = 0;
    }

    public Diem(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Phương thức in điểm
    public void InDiem()
    {
        Console.WriteLine($"({X}, {Y})");
    }

    // Tính khoảng cách giữa hai điểm
    public static double TinhKhoangCach(Diem d1, Diem d2)
    {
        return Math.Sqrt(Math.Pow(d2.X - d1.X, 2) + Math.Pow(d2.Y - d1.Y, 2));
    }
}

// 2. Lớp TamGiac
public class TamGiac
{
    private Diem d1;
    private Diem d2;
    private Diem d3;

    // Toán tử tạo lập
    public TamGiac()
    {
        d1 = new Diem();
        d2 = new Diem();
        d3 = new Diem();
    }

    public TamGiac(Diem d1, Diem d2, Diem d3)
    {
        this.d1 = d1;
        this.d2 = d2;
        this.d3 = d3;
    }

    // Nhập tam giác
    public void NhapTamGiac()
    {
        Console.WriteLine("Nhập điểm thứ nhất:");
        d1 = NhapDiem();

        Console.WriteLine("Nhập điểm thứ hai:");
        d2 = NhapDiem();

        Console.WriteLine("Nhập điểm thứ ba:");
        d3 = NhapDiem();

        while (!LaTamGiacHopLe())
        {
            Console.WriteLine("Ba điểm không tạo thành tam giác hợp lệ! Vui lòng nhập lại.");
            Console.WriteLine("Nhập điểm thứ nhất:");
            d1 = NhapDiem();
            Console.WriteLine("Nhập điểm thứ hai:");
            d2 = NhapDiem();
            Console.WriteLine("Nhập điểm thứ ba:");
            d3 = NhapDiem();
        }
    }

    private Diem NhapDiem()
    {
        Console.Write("Nhập hoành độ x: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Nhập tung độ y: ");
        double y = double.Parse(Console.ReadLine());
        return new Diem(x, y);
    }

    // Kiểm tra tam giác hợp lệ
    private bool LaTamGiacHopLe()
    {
        double a = Diem.TinhKhoangCach(d1, d2);
        double b = Diem.TinhKhoangCach(d2, d3);
        double c = Diem.TinhKhoangCach(d1, d3);

        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    // Tính chu vi tam giác
    public double TinhChuVi()
    {
        double a = Diem.TinhKhoangCach(d1, d2);
        double b = Diem.TinhKhoangCach(d2, d3);
        double c = Diem.TinhKhoangCach(d1, d3);

        return a + b + c;
    }

    // Tính diện tích tam giác (dùng công thức Heron)
    public double TinhDienTich()
    {
        double a = Diem.TinhKhoangCach(d1, d2);
        double b = Diem.TinhKhoangCach(d2, d3);
        double c = Diem.TinhKhoangCach(d1, d3);
        double p = TinhChuVi() / 2;

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    // Hiển thị tam giác
    public void HienThi()
    {
        Console.Write("Tam giác tạo bởi 3 điểm: ");
        d1.InDiem();
        Console.Write(", ");
        d2.InDiem();
        Console.Write(", ");
        d3.InDiem();
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
            tg.NhapTamGiac();
            danhSachTamGiac.Add(tg);
        }

        // Tính tổng chu vi và tổng diện tích
        double tongChuVi = 0;
        double tongDienTich = 0;

        foreach (TamGiac tg in danhSachTamGiac)
        {
            tongChuVi += tg.TinhChuVi();
            tongDienTich += tg.TinhDienTich();
        }

        // Hiển thị kết quả
        Console.WriteLine("\nKết quả:");
        Console.WriteLine($"Tổng chu vi của {n} tam giác: {tongChuVi:F2}");
        Console.WriteLine($"Tổng diện tích của {n} tam giác: {tongDienTich:F2}");
    }
}