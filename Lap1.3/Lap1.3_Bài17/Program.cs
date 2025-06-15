using System;
using System.Collections.Generic;

class Diem
{
    public float HoanhDo { get; set; }
    public float TungDo { get; set; }

    // Toán tử tạo lập
    public Diem()
    {
        HoanhDo = 0;
        TungDo = 0;
    }

    public Diem(float x, float y)
    {
        HoanhDo = x;
        TungDo = y;
    }

    // Phương thức in một đối tượng điểm
    public void InDiem()
    {
        Console.WriteLine($"Diem({HoanhDo}, {TungDo})");
    }

    // Phương thức tính khoảng cách giữa hai điểm
    public float TinhKhoangCach(Diem d)
    {
        return (float)Math.Sqrt(Math.Pow(HoanhDo - d.HoanhDo, 2) + Math.Pow(TungDo - d.TungDo, 2));
    }
}

class HinhTron
{
    public Diem Tam { get; set; }
    public float BanKinh { get; set; }

    // Toán tử tạo lập
    public HinhTron()
    {
        Tam = new Diem();
        BanKinh = 0;
    }

    public HinhTron(Diem d, float bk)
    {
        Tam = d;
        BanKinh = bk;
    }

    // Tính chu vi hình tròn
    public float TinhChuVi()
    {
        return 2 * (float)Math.PI * BanKinh;
    }

    // Tính diện tích hình tròn
    public float TinhDienTich()
    {
        return (float)Math.PI * (float)Math.Pow(BanKinh, 2);
    }

    // Phương thức kiểm tra giao nhau với một hình tròn khác
    public bool KiemTraGiao(HinhTron h)
    {
        float khoangCach = Tam.TinhKhoangCach(h.Tam);
        return khoangCach < BanKinh + h.BanKinh && khoangCach > Math.Abs(BanKinh - h.BanKinh);
    }

    // Phương thức in thông tin hình tròn
    public void InHinhTron()
    {
        Console.WriteLine($"Hình tròn có tâm tại ({Tam.HoanhDo}, {Tam.TungDo}) và bán kính {BanKinh}");
        Console.WriteLine($"Chu vi: {TinhChuVi()}");
        Console.WriteLine($"Diện tích: {TinhDienTich()}");
    }
}

class QLHinhTron
{
    public List<HinhTron> DanhSachHinhTron { get; set; }

    public QLHinhTron()
    {
        DanhSachHinhTron = new List<HinhTron>();
    }

    // Nhập thông tin danh sách các hình tròn
    public void NhapDanhSachHinhTron()
    {
        Console.Write("Nhập số lượng hình tròn: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin hình tròn thứ {i + 1}:");
            Console.Write("Nhập tọa độ tâm (hoành độ, tung độ): ");
            float x = float.Parse(Console.ReadLine());
            float y = float.Parse(Console.ReadLine());
            Diem tam = new Diem(x, y);

            Console.Write("Nhập bán kính hình tròn: ");
            float banKinh = float.Parse(Console.ReadLine());

            HinhTron hinhTron = new HinhTron(tam, banKinh);
            DanhSachHinhTron.Add(hinhTron);
        }
    }

    // Hiển thị hình tròn giao với nhiều hình tròn khác nhất
    public void HienThiHinhTronGiaoNhieuHinhNhat()
    {
        int maxGiao = 0;
        HinhTron hinhTronGiaoNhieu = null;

        foreach (var h1 in DanhSachHinhTron)
        {
            int soGiao = 0;
            foreach (var h2 in DanhSachHinhTron)
            {
                if (h1 != h2 && h1.KiemTraGiao(h2))
                {
                    soGiao++;
                }
            }

            if (soGiao > maxGiao)
            {
                maxGiao = soGiao;
                hinhTronGiaoNhieu = h1;
            }
        }

        if (hinhTronGiaoNhieu != null)
        {
            Console.WriteLine("Hình tròn giao với nhiều hình tròn nhất:");
            hinhTronGiaoNhieu.InHinhTron();
        }
        else
        {
            Console.WriteLine("Không có hình tròn giao với bất kỳ hình tròn nào.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        QLHinhTron ql = new QLHinhTron();
        ql.NhapDanhSachHinhTron();
        ql.HienThiHinhTronGiaoNhieuHinhNhat();
    }
}
