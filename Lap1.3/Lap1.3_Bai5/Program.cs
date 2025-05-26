using System;
using System.Collections.Generic;

// Lớp Người quản lý thông tin cá nhân
public class Nguoi
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string CMND { get; set; }

    public Nguoi() { }

    public Nguoi(string hoTen, int namSinh, string cmnd)
    {
        HoTen = hoTen;
        NamSinh = namSinh;
        CMND = cmnd;
    }

    public virtual void NhapThongTin()
    {
        Console.Write("Nhập họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhập năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Nhập số CMND: ");
        CMND = Console.ReadLine();
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Năm sinh: {NamSinh}");
        Console.WriteLine($"CMND: {CMND}");
    }
}

// Lớp Khách sạn kế thừa từ lớp Người
public class KhachSan : Nguoi
{
    public int SoNgayTro { get; set; }
    public string LoaiPhong { get; set; }
    public double GiaPhong { get; set; }

    public KhachSan() : base() { }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập số ngày trọ: ");
        SoNgayTro = int.Parse(Console.ReadLine());
        Console.Write("Nhập loại phòng (A/B/C): ");
        LoaiPhong = Console.ReadLine().ToUpper();

        // Thiết lập giá phòng theo loại
        switch (LoaiPhong)
        {
            case "A":
                GiaPhong = 500000;
                break;
            case "B":
                GiaPhong = 300000;
                break;
            case "C":
                GiaPhong = 200000;
                break;
            default:
                GiaPhong = 200000;
                break;
        }
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Số ngày trọ: {SoNgayTro}");
        Console.WriteLine($"Loại phòng: {LoaiPhong}");
        Console.WriteLine($"Giá phòng: {GiaPhong:N0} VND/ngày");
        Console.WriteLine($"Tổng tiền: {TinhTien():N0} VND");
        Console.WriteLine("----------------------------------");
    }

    public double TinhTien()
    {
        return SoNgayTro * GiaPhong;
    }
}

class Program
{
    static List<KhachSan> danhSachKhach = new List<KhachSan>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        int luaChon;
        do
        {
            Console.WriteLine("\n===== QUẢN LÝ KHÁCH SẠN =====");
            Console.WriteLine("1. Nhập thông tin khách trọ");
            Console.WriteLine("2. Hiển thị danh sách khách trọ");
            Console.WriteLine("3. Tìm kiếm khách trọ theo tên");
            Console.WriteLine("4. Thanh toán trả phòng");
            Console.WriteLine("5. Thoát chương trình");
            Console.Write("Nhập lựa chọn của bạn: ");

            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    NhapDanhSachKhach();
                    break;
                case 2:
                    HienThiDanhSachKhach();
                    break;
                case 3:
                    TimKiemKhachTheoTen();
                    break;
                case 4:
                    ThanhToanTraPhong();
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

    static void NhapDanhSachKhach()
    {
        Console.Write("Nhập số lượng khách trọ: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập thông tin khách trọ thứ {i + 1}:");
            KhachSan khach = new KhachSan();
            khach.NhapThongTin();
            danhSachKhach.Add(khach);
        }
    }

    static void HienThiDanhSachKhach()
    {
        Console.WriteLine("\n===== DANH SÁCH KHÁCH TRỌ =====");
        if (danhSachKhach.Count == 0)
        {
            Console.WriteLine("Không có khách nào trong danh sách!");
            return;
        }

        foreach (var khach in danhSachKhach)
        {
            khach.HienThiThongTin();
        }
    }

    static void TimKiemKhachTheoTen()
    {
        Console.Write("\nNhập tên khách cần tìm: ");
        string tenCanTim = Console.ReadLine().ToLower();
        bool timThay = false;

        foreach (var khach in danhSachKhach)
        {
            if (khach.HoTen.ToLower().Contains(tenCanTim))
            {
                khach.HienThiThongTin();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy khách trọ với tên đã nhập!");
        }
    }

    static void ThanhToanTraPhong()
    {
        Console.Write("\nNhập số CMND của khách thanh toán: ");
        string cmnd = Console.ReadLine();
        bool timThay = false;

        foreach (var khach in danhSachKhach)
        {
            if (khach.CMND == cmnd)
            {
                Console.WriteLine("\nTHÔNG TIN THANH TOÁN");
                khach.HienThiThongTin();
                Console.WriteLine($"Tổng số tiền cần thanh toán: {khach.TinhTien():N0} VND");
                danhSachKhach.Remove(khach);
                Console.WriteLine("Đã thanh toán và xóa khách khỏi danh sách!");
                timThay = true;
                break;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy khách trọ với CMND đã nhập!");
        }
    }
}