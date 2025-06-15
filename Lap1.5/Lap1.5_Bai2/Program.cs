using System;
using System.Collections.Generic;

abstract class Hinh
{
    public abstract double TinhChuVi();
    public abstract double TinhDienTich();
    public abstract void NhapThongTin();
}

class HinhTron : Hinh
{
    public double BanKinh { get; set; }

    public override void NhapThongTin()
    {
        Console.Write("Nhập bán kính hình tròn: ");
        BanKinh = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi() => 2 * Math.PI * BanKinh;

    public override double TinhDienTich() => Math.PI * BanKinh * BanKinh;
}

class HinhVuong : Hinh
{
    public double Canh { get; set; }

    public override void NhapThongTin()
    {
        Console.Write("Nhập độ dài cạnh hình vuông: ");
        Canh = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi() => 4 * Canh;

    public override double TinhDienTich() => Canh * Canh;
}

class HinhChuNhat : Hinh
{
    public double Dai { get; set; }
    public double Rong { get; set; }

    public override void NhapThongTin()
    {
        Console.Write("Nhập chiều dài hình chữ nhật: ");
        Dai = double.Parse(Console.ReadLine());
        Console.Write("Nhập chiều rộng hình chữ nhật: ");
        Rong = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi() => 2 * (Dai + Rong);

    public override double TinhDienTich() => Dai * Rong;
}

class HinhTamGiac : Hinh
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public override void NhapThongTin()
    {
        Console.Write("Nhập cạnh a: ");
        A = double.Parse(Console.ReadLine());
        Console.Write("Nhập cạnh b: ");
        B = double.Parse(Console.ReadLine());
        Console.Write("Nhập cạnh c: ");
        C = double.Parse(Console.ReadLine());

        // Kiểm tra hợp lệ tam giác
        while (A + B <= C || A + C <= B || B + C <= A)
        {
            Console.WriteLine("Ba cạnh không hợp lệ. Nhập lại!");
            NhapThongTin();
        }
    }

    public override double TinhChuVi() => A + B + C;

    public override double TinhDienTich()
    {
        double p = TinhChuVi() / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C)); // Công thức Heron
    }
}

class Program
{
    static void Main()
    {
        
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        List<Hinh> danhSachHinh = new List<Hinh>();

        Console.Write("Nhập số lượng hình: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nHình thứ {i + 1}:");
            Console.WriteLine("1. Hình tròn");
            Console.WriteLine("2. Hình vuông");
            Console.WriteLine("3. Hình chữ nhật");
            Console.WriteLine("4. Hình tam giác");
            Console.Write("Chọn loại hình (1-4): ");
            int chon = int.Parse(Console.ReadLine());

            Hinh hinh = chon switch
            {
                1 => new HinhTron(),
                2 => new HinhVuong(),
                3 => new HinhChuNhat(),
                4 => new HinhTamGiac(),
                _ => null
            };

            if (hinh != null)
            {
                hinh.NhapThongTin();
                danhSachHinh.Add(hinh);
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                i--; // yêu cầu nhập lại hình này
            }
        }

        double tongChuVi = 0;
        double tongDienTich = 0;

        foreach (var h in danhSachHinh)
        {
            tongChuVi += h.TinhChuVi();
            tongDienTich += h.TinhDienTich();
        }

        Console.WriteLine($"\nTổng chu vi các hình: {tongChuVi:F2}");
        Console.WriteLine($"Tổng diện tích các hình: {tongDienTich:F2}");
    }
}
