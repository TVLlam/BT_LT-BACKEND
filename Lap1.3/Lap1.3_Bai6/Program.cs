using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyHSSV
{
    // Lớp Nguoi để quản lý thông tin cá nhân của học sinh
    class Nguoi
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public int NamSinh { get; set; }
        public string QueQuan { get; set; }
        public string GioiTinh { get; set; }

        // Nhập thông tin cá nhân
        public void Nhap()
        {
            Console.Write("Nhập họ và tên: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhập tuổi: ");
            Tuoi = int.Parse(Console.ReadLine());

            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());

            Console.Write("Nhập quê quán: ");
            QueQuan = Console.ReadLine();

            Console.Write("Nhập giới tính: ");
            GioiTinh = Console.ReadLine();
        }

        // Hiển thị thông tin cá nhân
        public void HienThi()
        {
            Console.WriteLine($"Họ tên: {HoTen}, Tuổi: {Tuoi}, Năm sinh: {NamSinh}, Quê quán: {QueQuan}, Giới tính: {GioiTinh}");
        }
    }

    // Lớp HSHocSinh để quản lý hồ sơ học sinh
    class HSHocSinh
    {
        public string Lop { get; set; }
        public string KhoaHoc { get; set; }
        public string KyHoc { get; set; }
        public Nguoi ThongTinCaNhan { get; set; }

        public HSHocSinh()
        {
            ThongTinCaNhan = new Nguoi();
        }

        // Nhập thông tin hồ sơ học sinh
        public void Nhap()
        {
            Console.Write("Nhập lớp học: ");
            Lop = Console.ReadLine();

            Console.Write("Nhập khóa học: ");
            KhoaHoc = Console.ReadLine();

            Console.Write("Nhập kỳ học: ");
            KyHoc = Console.ReadLine();

            ThongTinCaNhan.Nhap();
        }

        // Hiển thị thông tin hồ sơ học sinh
        public void HienThi()
        {
            Console.WriteLine($"Lớp: {Lop}, Khóa học: {KhoaHoc}, Kỳ học: {KyHoc}");
            ThongTinCaNhan.HienThi();
        }
    }

    // Lớp QuanLyHocSinh để quản lý danh sách học sinh
    class QuanLyHocSinh
    {
        private List<HSHocSinh> danhSachHocSinh = new List<HSHocSinh>();

        // Nhập thông tin các học sinh
        public void NhapThongTinHocSinh()
        {
            Console.Write("Nhập số lượng học sinh: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thông tin học sinh thứ {i + 1}:");
                HSHocSinh hs = new HSHocSinh();
                hs.Nhap();
                danhSachHocSinh.Add(hs);
            }
        }

        // Hiển thị thông tin học sinh nữ và sinh năm 1985
        public void HienThiHocSinhNuSinhNam1985()
        {
            Console.WriteLine("\n--- Học sinh nữ sinh năm 1985 ---");
            bool timThay = false;
            foreach (var hs in danhSachHocSinh)
            {
                if (hs.ThongTinCaNhan.GioiTinh.ToLower() == "nữ" && hs.ThongTinCaNhan.NamSinh == 1985)
                {
                    hs.HienThi();
                    timThay = true;
                }
            }
            if (!timThay)
            {
                Console.WriteLine("Không có học sinh nữ sinh năm 1985.");
            }
        }

        // Tìm kiếm học sinh theo quê quán
        public void TimKiemTheoQueQuan(string queQuan)
        {
            Console.WriteLine($"\nTìm kiếm học sinh theo quê quán: {queQuan}");
            bool timThay = false;
            foreach (var hs in danhSachHocSinh)
            {
                if (hs.ThongTinCaNhan.QueQuan.ToLower().Contains(queQuan.ToLower()))
                {
                    hs.HienThi();
                    timThay = true;
                }
            }
            if (!timThay)
            {
                Console.WriteLine("Không có học sinh nào có quê quán này.");
            }
        }

        // Menu chương trình
        public void Menu()
        {
            int luaChon;
            do
            {
                Console.WriteLine("\n===== QUẢN LÝ HỒ SƠ HỌC SINH =====");
                Console.WriteLine("1. Nhập thông tin học sinh");
                Console.WriteLine("2. Hiển thị học sinh nữ sinh năm 1985");
                Console.WriteLine("3. Tìm kiếm học sinh theo quê quán");
                Console.WriteLine("4. Thoát");
                Console.Write("Lựa chọn: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        NhapThongTinHocSinh();
                        break;
                    case 2:
                        HienThiHocSinhNuSinhNam1985();
                        break;
                    case 3:
                        Console.Write("Nhập quê quán cần tìm: ");
                        string queQuan = Console.ReadLine();
                        TimKiemTheoQueQuan(queQuan);
                        break;
                    case 4:
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            } while (luaChon != 4);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 

            QuanLyHocSinh qlh = new QuanLyHocSinh();
            qlh.Menu();
        }
    }
}
