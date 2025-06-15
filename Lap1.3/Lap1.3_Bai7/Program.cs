using System;
using System.Collections.Generic;

// Lớp Người quản lý thông tin cá nhân
public class Nguoi
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string QueQuan { get; set; }
    public string CMND { get; set; }

    public Nguoi() { }

    public Nguoi(string hoTen, int namSinh, string queQuan, string cmnd)
    {
        HoTen = hoTen;
        NamSinh = namSinh;
        QueQuan = queQuan;
        CMND = cmnd;
    }

    public virtual void NhapThongTin()
    {
        Console.Write("Nhập họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhập năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Nhập quê quán: ");
        QueQuan = Console.ReadLine();
        Console.Write("Nhập số CMND: ");
        CMND = Console.ReadLine();
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Năm sinh: {NamSinh}");
        Console.WriteLine($"Quê quán: {QueQuan}");
        Console.WriteLine($"CMND: {CMND}");
    }
}

// Lớp Cán bộ giáo viên kế thừa từ lớp Người
public class CBGV : Nguoi
{
    public double LuongCung { get; set; }
    public double Thuong { get; set; }
    public double Phat { get; set; }
    public double LuongThucLinh { get; private set; }

    public CBGV() : base() { }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập lương cứng: ");
        LuongCung = double.Parse(Console.ReadLine());
        Console.Write("Nhập thưởng: ");
        Thuong = double.Parse(Console.ReadLine());
        Console.Write("Nhập phạt: ");
        Phat = double.Parse(Console.ReadLine());
        TinhLuongThucLinh();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Lương cứng: {LuongCung:N0} VND");
        Console.WriteLine($"Thưởng: {Thuong:N0} VND");
        Console.WriteLine($"Phạt: {Phat:N0} VND");
        Console.WriteLine($"Lương thực lĩnh: {LuongThucLinh:N0} VND");
        Console.WriteLine("----------------------------------");
    }

    public void TinhLuongThucLinh()
    {
        LuongThucLinh = LuongCung + Thuong - Phat;
    }
}

class Program
{
    static List<CBGV> danhSachCBGV = new List<CBGV>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        int luaChon;
        do
        {
            Console.WriteLine("\n===== QUẢN LÝ CÁN BỘ GIÁO VIÊN =====");
            Console.WriteLine("1. Nhập thông tin cán bộ giáo viên");
            Console.WriteLine("2. Hiển thị danh sách cán bộ giáo viên");
            Console.WriteLine("3. Tìm kiếm cán bộ theo quê quán");
            Console.WriteLine("4. Hiển thị cán bộ có lương thực lĩnh > 5 triệu");
            Console.WriteLine("5. Thoát chương trình");
            Console.Write("Nhập lựa chọn của bạn: ");

            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    NhapDanhSachCBGV();
                    break;
                case 2:
                    HienThiDanhSachCBGV();
                    break;
                case 3:
                    TimKiemTheoQueQuan();
                    break;
                case 4:
                    HienThiCBGVCaLuongCao();
                    break;
                case 5:
                    Console.WriteLine("Cảm ơn đã sử dụng chương trình!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        } while (luaChon != 5);
    }

    static void NhapDanhSachCBGV()
    {
        Console.Write("Nhập số lượng cán bộ giáo viên: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập thông tin cán bộ giáo viên thứ {i + 1}:");
            CBGV cbgv = new CBGV();
            cbgv.NhapThongTin();
            danhSachCBGV.Add(cbgv);
        }
    }

    static void HienThiDanhSachCBGV()
    {
        Console.WriteLine("\n===== DANH SÁCH CÁN BỘ GIÁO VIÊN =====");
        if (danhSachCBGV.Count == 0)
        {
            Console.WriteLine("Không có cán bộ nào trong danh sách!");
            return;
        }

        foreach (var cbgv in danhSachCBGV)
        {
            cbgv.HienThiThongTin();
        }
    }

    static void TimKiemTheoQueQuan()
    {
        Console.Write("\nNhập quê quán cần tìm: ");
        string queQuanCanTim = Console.ReadLine().ToLower();
        bool timThay = false;

        foreach (var cbgv in danhSachCBGV)
        {
            if (cbgv.QueQuan.ToLower().Contains(queQuanCanTim))
            {
                cbgv.HienThiThongTin();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy cán bộ giáo viên với quê quán đã nhập!");
        }
    }

    static void HienThiCBGVCaLuongCao()
    {
        Console.WriteLine("\n===== DANH SÁCH CÁN BỘ CÓ LƯƠNG > 5 TRIỆU =====");
        bool coCBGV = false;

        foreach (var cbgv in danhSachCBGV)
        {
            if (cbgv.LuongThucLinh > 5000000)
            {
                cbgv.HienThiThongTin();
                coCBGV = true;
            }
        }

        if (!coCBGV)
        {
            Console.WriteLine("Không có cán bộ giáo viên nào có lương thực lĩnh trên 5 triệu!");
        }
    }
}