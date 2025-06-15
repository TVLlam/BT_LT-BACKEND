using System;
using System.Collections.Generic;

// Lớp Khách hàng quản lý thông tin hộ sử dụng điện
public class KhachHang
{
    public string HoTenChuHo { get; set; }
    public string SoNha { get; set; }
    public string MaSoCongTo { get; set; }

    public KhachHang() { }

    public KhachHang(string hoTen, string soNha, string maCongTo)
    {
        HoTenChuHo = hoTen;
        SoNha = soNha;
        MaSoCongTo = maCongTo;
    }

    public virtual void NhapThongTin()
    {
        Console.Write("Nhập họ tên chủ hộ: ");
        HoTenChuHo = Console.ReadLine();
        Console.Write("Nhập số nhà: ");
        SoNha = Console.ReadLine();
        Console.Write("Nhập mã số công tơ: ");
        MaSoCongTo = Console.ReadLine();
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên chủ hộ: {HoTenChuHo}");
        Console.WriteLine($"Số nhà: {SoNha}");
        Console.WriteLine($"Mã số công tơ: {MaSoCongTo}");
    }
}

// Lớp Biên lai kế thừa từ lớp Khách hàng
public class BienLai : KhachHang
{
    public int ChiSoCu { get; set; }
    public int ChiSoMoi { get; set; }
    public double SoTienPhaiTra { get; private set; }

    public BienLai() : base() { }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhập chỉ số cũ: ");
        ChiSoCu = int.Parse(Console.ReadLine());
        Console.Write("Nhập chỉ số mới: ");
        ChiSoMoi = int.Parse(Console.ReadLine());
        TinhTienDien();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Chỉ số cũ: {ChiSoCu}");
        Console.WriteLine($"Chỉ số mới: {ChiSoMoi}");
        Console.WriteLine($"Số tiền phải trả: {SoTienPhaiTra:N0} VND");
        Console.WriteLine("----------------------------------");
    }

    public void TinhTienDien()
    {
        int soDienTieuThu = ChiSoMoi - ChiSoCu;

        if (soDienTieuThu < 0)
        {
            Console.WriteLine("Cảnh báo: Chỉ số mới nhỏ hơn chỉ số cũ!");
            SoTienPhaiTra = 0;
            return;
        }

        if (soDienTieuThu < 50)
        {
            SoTienPhaiTra = soDienTieuThu * 1250;
        }
        else if (soDienTieuThu < 100)
        {
            SoTienPhaiTra = 50 * 1250 + (soDienTieuThu - 50) * 1500;
        }
        else
        {
            SoTienPhaiTra = 50 * 1250 + 50 * 1500 + (soDienTieuThu - 100) * 2000;
        }
    }
}

class Program
{
    static List<BienLai> danhSachBienLai = new List<BienLai>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        int luaChon;
        do
        {
            Console.WriteLine("\n===== QUẢN LÝ BIÊN LAI TIỀN ĐIỆN =====");
            Console.WriteLine("1. Nhập thông tin biên lai");
            Console.WriteLine("2. Hiển thị danh sách biên lai");
            Console.WriteLine("3. Thoát chương trình");
            Console.Write("Nhập lựa chọn của bạn: ");

            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    NhapDanhSachBienLai();
                    break;
                case 2:
                    HienThiDanhSachBienLai();
                    break;
                case 3:
                    Console.WriteLine("Cảm ơn đã sử dụng chương trình!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        } while (luaChon != 3);
    }

    static void NhapDanhSachBienLai()
    {
        Console.Write("Nhập số lượng hộ sử dụng điện: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập thông tin hộ thứ {i + 1}:");
            BienLai bienLai = new BienLai();
            bienLai.NhapThongTin();
            danhSachBienLai.Add(bienLai);
        }
    }

    static void HienThiDanhSachBienLai()
    {
        Console.WriteLine("\n===== DANH SÁCH BIÊN LAI =====");
        if (danhSachBienLai.Count == 0)
        {
            Console.WriteLine("Không có biên lai nào trong danh sách!");
            return;
        }

        foreach (var bienLai in danhSachBienLai)
        {
            bienLai.HienThiThongTin();
        }
    }
}