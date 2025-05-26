using System;
using System.Collections.Generic;

// Lớp cơ sở HoiVien
public class HoiVien
{
    public string HoTen { get; set; }
    public string DiaChi { get; set; }

    public HoiVien() { }

    public HoiVien(string hoTen, string diaChi)
    {
        HoTen = hoTen;
        DiaChi = diaChi;
    }

    public virtual void NhapThongTin()
    {
        Console.Write("Nhập họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhập địa chỉ: ");
        DiaChi = Console.ReadLine();
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Địa chỉ: {DiaChi}");
    }
}

// Lớp hội viên đã có gia đình
public class HoiVienCoGiaDinh : HoiVien
{
    public string HoTenVoChong { get; set; }
    public string NgayCuoi { get; set; }

    public HoiVienCoGiaDinh() : base() { }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập họ tên vợ/chồng: ");
        HoTenVoChong = Console.ReadLine();
        Console.Write("Nhập ngày cưới (dd.MM.yyyy): ");
        NgayCuoi = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Họ tên vợ/chồng: {HoTenVoChong}");
        Console.WriteLine($"Ngày cưới: {NgayCuoi}");
    }
}

// Lớp hội viên có người yêu
public class HoiVienCoNguoiYeu : HoiVien
{
    public string HoTenNguoiYeu { get; set; }
    public string SoDienThoaiNguoiYeu { get; set; }

    public HoiVienCoNguoiYeu() : base() { }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập họ tên người yêu: ");
        HoTenNguoiYeu = Console.ReadLine();
        Console.Write("Nhập số điện thoại người yêu: ");
        SoDienThoaiNguoiYeu = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Họ tên người yêu: {HoTenNguoiYeu}");
        Console.WriteLine($"Số điện thoại người yêu: {SoDienThoaiNguoiYeu}");
    }
}

class Program
{
    static List<HoiVien> danhSachHoiVien = new List<HoiVien>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        int luaChon;
        do
        {
            Console.WriteLine("\n===== QUẢN LÝ HỘI VIÊN =====");
            Console.WriteLine("1. Nhập danh sách hội viên");
            Console.WriteLine("2. Tìm hội viên có ngày cưới 11.11.2011");
            Console.WriteLine("3. Hiển thị hội viên có người yêu nhưng chưa lập gia đình");
            Console.WriteLine("4. Thoát chương trình");
            Console.Write("Nhập lựa chọn của bạn: ");

            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    NhapDanhSachHoiVien();
                    break;
                case 2:
                    TimHoiVienNgayCuoi11112011();
                    break;
                case 3:
                    HienThiHoiVienCoNguoiYeuChuaCuoi();
                    break;
                case 4:
                    Console.WriteLine("Cảm ơn đã sử dụng chương trình!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        } while (luaChon != 4);
    }

    static void NhapDanhSachHoiVien()
    {
        Console.Write("Nhập số lượng hội viên: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập thông tin hội viên thứ {i + 1}:");
            Console.WriteLine("1. Chưa có người yêu");
            Console.WriteLine("2. Có người yêu");
            Console.WriteLine("3. Đã có gia đình");
            Console.Write("Chọn tình trạng hôn nhân: ");
            int tinhTrang = int.Parse(Console.ReadLine());

            HoiVien hoiVien;
            switch (tinhTrang)
            {
                case 1:
                    hoiVien = new HoiVien();
                    break;
                case 2:
                    hoiVien = new HoiVienCoNguoiYeu();
                    break;
                case 3:
                    hoiVien = new HoiVienCoGiaDinh();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, mặc định là chưa có người yêu");
                    hoiVien = new HoiVien();
                    break;
            }

            hoiVien.NhapThongTin();
            danhSachHoiVien.Add(hoiVien);
        }
    }

    static void TimHoiVienNgayCuoi11112011()
    {
        Console.WriteLine("\n===== DANH SÁCH HỘI VIÊN CÓ NGÀY CƯỚI 11.11.2011 =====");
        bool timThay = false;

        foreach (var hv in danhSachHoiVien)
        {
            if (hv is HoiVienCoGiaDinh hvgd && hvgd.NgayCuoi == "11.11.2011")
            {
                hvgd.HienThiThongTin();
                Console.WriteLine("----------------------------------");
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy hội viên nào có ngày cưới 11.11.2011!");
        }
    }

    static void HienThiHoiVienCoNguoiYeuChuaCuoi()
    {
        Console.WriteLine("\n===== DANH SÁCH HỘI VIÊN CÓ NGƯỜI YÊU NHƯNG CHƯA LẬP GIA ĐÌNH =====");
        bool timThay = false;

        foreach (var hv in danhSachHoiVien)
        {
            if (hv is HoiVienCoNguoiYeu hvny && !(hv is HoiVienCoGiaDinh))
            {
                hvny.HienThiThongTin();
                Console.WriteLine("----------------------------------");
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy hội viên nào có người yêu nhưng chưa lập gia đình!");
        }
    }
}