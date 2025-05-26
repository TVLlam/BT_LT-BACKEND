using System;
using System.Collections.Generic;

// 1. Lớp Nguoi
public class Nguoi
{
    public string HoTen { get; set; }
    public bool GioiTinh { get; set; } // true: Nam, false: Nữ
    public int Tuoi { get; set; }

    // Các toán tử tạo lập
    public Nguoi()
    {
        HoTen = "";
        GioiTinh = true;
        Tuoi = 0;
    }

    public Nguoi(string hoTen, bool gioiTinh, int tuoi)
    {
        HoTen = hoTen;
        GioiTinh = gioiTinh;
        Tuoi = tuoi;
    }

    // Phương thức in thông tin
    public virtual void InThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Giới tính: {(GioiTinh ? "Nam" : "Nữ")}");
        Console.WriteLine($"Tuổi: {Tuoi}");
    }
}

// 2. Lớp CoQuan kế thừa từ Nguoi
public class CoQuan : Nguoi
{
    public string DonVi { get; set; }
    public double HeSoLuong { get; set; }
    public const double LUONG_CO_BAN = 1050000; // 1.050.000 VND

    public CoQuan() : base()
    {
        DonVi = "";
        HeSoLuong = 0;
    }

    public CoQuan(string hoTen, bool gioiTinh, int tuoi, string donVi, double heSoLuong)
        : base(hoTen, gioiTinh, tuoi)
    {
        DonVi = donVi;
        HeSoLuong = heSoLuong;
    }

    // Ghi đè phương thức in thông tin
    public override void InThongTin()
    {
        base.InThongTin();
        Console.WriteLine($"Đơn vị: {DonVi}");
        Console.WriteLine($"Hệ số lương: {HeSoLuong}");
        Console.WriteLine($"Lương: {TinhLuong():N0} VND");
        Console.WriteLine("----------------------------------");
    }

    // Phương thức tính lương
    public double TinhLuong()
    {
        return HeSoLuong * LUONG_CO_BAN;
    }

    // Phương thức nhập thông tin
    public void NhapThongTin()
    {
        Console.Write("Nhập họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhập giới tính (Nam/Nữ): ");
        GioiTinh = Console.ReadLine().ToLower() == "nam";
        Console.Write("Nhập tuổi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Nhập đơn vị công tác: ");
        DonVi = Console.ReadLine();
        Console.Write("Nhập hệ số lương: ");
        HeSoLuong = double.Parse(Console.ReadLine());
    }
}

// 3. Ứng dụng chính
class Program
{
    static List<CoQuan> danhSachCanBo = new List<CoQuan>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        int luaChon;
        do
        {
            Console.WriteLine("\n===== QUẢN LÝ CÁN BỘ CƠ QUAN =====");
            Console.WriteLine("1. Nhập danh sách cán bộ");
            Console.WriteLine("2. Hiển thị cán bộ Phòng Tài chính");
            Console.WriteLine("3. Tìm kiếm theo họ tên");
            Console.WriteLine("4. Thoát chương trình");
            Console.Write("Nhập lựa chọn của bạn: ");

            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    NhapDanhSach();
                    break;
                case 2:
                    HienThiPhongTaiChinh();
                    break;
                case 3:
                    TimKiemTheoTen();
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

    static void NhapDanhSach()
    {
        Console.Write("Nhập số lượng cán bộ: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập thông tin cán bộ thứ {i + 1}:");
            CoQuan cb = new CoQuan();
            cb.NhapThongTin();
            danhSachCanBo.Add(cb);
        }
    }

    static void HienThiPhongTaiChinh()
    {
        Console.WriteLine("\n===== DANH SÁCH CÁN BỘ PHÒNG TÀI CHÍNH =====");
        bool timThay = false;

        foreach (var cb in danhSachCanBo)
        {
            if (cb.DonVi.ToLower().Contains("tài chính") || cb.DonVi.ToLower().Contains("tai chinh"))
            {
                cb.InThongTin();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy cán bộ nào thuộc Phòng Tài chính!");
        }
    }

    static void TimKiemTheoTen()
    {
        Console.Write("\nNhập tên cán bộ cần tìm: ");
        string tenCanTim = Console.ReadLine().ToLower();
        bool timThay = false;

        Console.WriteLine("\n===== KẾT QUẢ TÌM KIẾM =====");
        foreach (var cb in danhSachCanBo)
        {
            if (cb.HoTen.ToLower().Contains(tenCanTim))
            {
                cb.InThongTin();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy cán bộ nào phù hợp!");
        }
    }
}