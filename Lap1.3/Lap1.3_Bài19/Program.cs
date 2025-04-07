using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    // Cấu trúc để lưu thông tin Họ tên
    public struct HoTen
    {
        public string Ho;
        public string TenDem;
        public string Ten;
    }

    // Cấu trúc để lưu thông tin Quê quán
    public struct QueQuan
    {
        public string Xa;
        public string Huyen;
        public string Tinh;
    }

    // Cấu trúc để lưu thông tin Điểm thi
    public struct DiemThi
    {
        public float Toan;
        public float Ly;
        public float Hoa;
    }

    // Lớp Thí sinh
    public class THISINH
    {
        public HoTen HoTen;
        public QueQuan QueQuan;
        public string Truong;
        public int Tuoi;
        public string SoBaoDanh;
        public DiemThi DiemThi;

        // Phương thức nhập thông tin thí sinh
        public void NhapThongTin()
        {
            // Nhập thông tin Họ tên
            Console.WriteLine("Nhập Họ: ");
            HoTen.Ho = Console.ReadLine();
            Console.WriteLine("Nhập Tên đệm: ");
            HoTen.TenDem = Console.ReadLine();
            Console.WriteLine("Nhập Tên: ");
            HoTen.Ten = Console.ReadLine();

            // Nhập thông tin Quê quán
            Console.WriteLine("Nhập Xã: ");
            QueQuan.Xa = Console.ReadLine();
            Console.WriteLine("Nhập Huyện: ");
            QueQuan.Huyen = Console.ReadLine();
            Console.WriteLine("Nhập Tỉnh: ");
            QueQuan.Tinh = Console.ReadLine();

            // Nhập thông tin Trường, Tuổi, Số báo danh
            Console.WriteLine("Nhập Trường: ");
            Truong = Console.ReadLine();
            Console.WriteLine("Nhập Tuổi: ");
            Tuoi = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập Số báo danh: ");
            SoBaoDanh = Console.ReadLine();

            // Nhập thông tin Điểm thi
            Console.WriteLine("Nhập Điểm Toán: ");
            DiemThi.Toan = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhập Điểm Lý: ");
            DiemThi.Ly = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhập Điểm Hóa: ");
            DiemThi.Hoa = float.Parse(Console.ReadLine());
        }

        // Phương thức tính tổng điểm
        public float TinhTongDiem()
        {
            return DiemThi.Toan + DiemThi.Ly + DiemThi.Hoa;
        }

        // Phương thức in thông tin thí sinh
        public void InThongTin()
        {
            Console.WriteLine("Họ tên: " + HoTen.Ho + " " + HoTen.TenDem + " " + HoTen.Ten);
            Console.WriteLine("Quê quán: " + QueQuan.Xa + ", " + QueQuan.Huyen + ", " + QueQuan.Tinh);
            Console.WriteLine("Trường: " + Truong);
            Console.WriteLine("Tuổi: " + Tuoi);
            Console.WriteLine("Số báo danh: " + SoBaoDanh);
            Console.WriteLine("Điểm Toán: " + DiemThi.Toan);
            Console.WriteLine("Điểm Lý: " + DiemThi.Ly);
            Console.WriteLine("Điểm Hóa: " + DiemThi.Hoa);
        }
    }

    // Bộ so sánh dùng để sắp xếp theo tổng điểm giảm dần
    public class SoSanhThiSinh : IComparer<THISINH>
    {
        public int Compare(THISINH a, THISINH b)
        {
            // So sánh tổng điểm, giảm dần nên đảo ngược kết quả so sánh
            return b.TinhTongDiem().CompareTo(a.TinhTongDiem());
        }
    }

    static void Main(string[] args)
    {
        // Đảm bảo sử dụng UTF-8 cho console
        Console.OutputEncoding = Encoding.UTF8;

        List<THISINH> danhSachThiSinh = new List<THISINH>();
        int n;

        // Nhập số lượng thí sinh
        Console.Write("Nhập số lượng thí sinh: ");
        n = int.Parse(Console.ReadLine());

        // Nhập thông tin cho mỗi thí sinh
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin thí sinh thứ {i + 1}: ");
            THISINH ts = new THISINH();
            ts.NhapThongTin();
            danhSachThiSinh.Add(ts);
        }

        // Tìm kiếm thí sinh có tổng điểm > 15
        Console.WriteLine("\nCác thí sinh có tổng điểm lớn hơn 15: ");
        foreach (var ts in danhSachThiSinh)
        {
            if (ts.TinhTongDiem() > 15)
            {
                ts.InThongTin();
                Console.WriteLine();
            }
        }

        // Sắp xếp danh sách thí sinh theo tổng điểm giảm dần sử dụng IComparer
        danhSachThiSinh.Sort(new SoSanhThiSinh());

        // Hiển thị thông tin danh sách thí sinh sau khi sắp xếp
        Console.WriteLine("\nDanh sách thí sinh sau khi sắp xếp theo tổng điểm giảm dần:");
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine("| Họ tên                         | Quê quán                    | Số báo danh | Tổng điểm |");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var ts in danhSachThiSinh)
        {
            string hoTen = $"{ts.HoTen.Ho} {ts.HoTen.TenDem} {ts.HoTen.Ten}";
            string queQuan = $"{ts.QueQuan.Xa}, {ts.QueQuan.Huyen}, {ts.QueQuan.Tinh}";
            Console.WriteLine($"| {hoTen,-30} | {queQuan,-25} | {ts.SoBaoDanh,-11} | {ts.TinhTongDiem(),-10:F1} |");
        }
        Console.WriteLine("--------------------------------------------------------------------------");
    }
}
