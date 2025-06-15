using System;
using System.Collections.Generic;

namespace QuanLyMuonSach
{
    // Lớp SinhVien để quản lý thông tin cá nhân của sinh viên
    class SinhVien
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public string Lop { get; set; }
        public string MaSoSinhVien { get; set; }

        // Nhập thông tin cá nhân của sinh viên
        public void Nhap()
        {
            Console.Write("Nhập họ và tên: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());

            Console.Write("Nhập lớp: ");
            Lop = Console.ReadLine();

            Console.Write("Nhập mã số sinh viên: ");
            MaSoSinhVien = Console.ReadLine();
        }

        // Hiển thị thông tin cá nhân của sinh viên
        public void HienThi()
        {
            Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, Lớp: {Lop}, Mã số sinh viên: {MaSoSinhVien}");
        }
    }

    // Lớp TheMuon để quản lý thông tin thẻ mượn sách
    class TheMuon
    {
        public string SoPhieuMuon { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public string SoHieuSach { get; set; }
        public SinhVien SinhVienMuon { get; set; }

        public TheMuon()
        {
            SinhVienMuon = new SinhVien();
        }

        // Nhập thông tin thẻ mượn
        public void Nhap()
        {
            Console.Write("Nhập số phiếu mượn: ");
            SoPhieuMuon = Console.ReadLine();

            Console.Write("Nhập ngày mượn (dd/MM/yyyy): ");
            NgayMuon = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Nhập hạn trả (dd/MM/yyyy): ");
            HanTra = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Nhập số hiệu sách: ");
            SoHieuSach = Console.ReadLine();

            Console.WriteLine("Nhập thông tin sinh viên mượn sách:");
            SinhVienMuon.Nhap();
        }

        // Hiển thị thông tin thẻ mượn
        public void HienThi()
        {
            Console.WriteLine($"Số phiếu mượn: {SoPhieuMuon}, Ngày mượn: {NgayMuon.ToShortDateString()}, Hạn trả: {HanTra.ToShortDateString()}, Số hiệu sách: {SoHieuSach}");
            SinhVienMuon.HienThi();
        }
    }

    // Lớp QuanLyMuonSach để quản lý danh sách thẻ mượn
    class QuanLyMuonSach
    {
        private List<TheMuon> danhSachTheMuon = new List<TheMuon>();

        // Nhập thông tin các thẻ mượn
        public void NhapThongTinMuonSach()
        {
            Console.Write("Nhập số lượng thẻ mượn: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thông tin thẻ mượn thứ {i + 1}:");
                TheMuon tm = new TheMuon();
                tm.Nhap();
                danhSachTheMuon.Add(tm);
            }
        }

        // Tìm kiếm thông tin sinh viên theo mã số sinh viên
        public void TimKiemSinhVienTheoMaSo(string maSoSinhVien)
        {
            Console.WriteLine($"\nTìm kiếm sinh viên theo mã số: {maSoSinhVien}");
            bool timThay = false;
            foreach (var tm in danhSachTheMuon)
            {
                if (tm.SinhVienMuon.MaSoSinhVien == maSoSinhVien)
                {
                    tm.HienThi();
                    timThay = true;
                }
            }
            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy sinh viên với mã số này.");
            }
        }

        // Hiển thị thông tin các sinh viên đã đến hạn trả sách
        public void HienThiSinhVienDenHanTra()
        {
            Console.WriteLine("\n--- Sinh viên đã đến hạn trả sách ---");
            bool timThay = false;
            DateTime ngayHienTai = DateTime.Now;
            foreach (var tm in danhSachTheMuon)
            {
                if (tm.HanTra <= ngayHienTai)
                {
                    tm.HienThi();
                    timThay = true;
                }
            }
            if (!timThay)
            {
                Console.WriteLine("Không có sinh viên nào đã đến hạn trả sách.");
            }
        }

        // Menu chương trình
        public void Menu()
        {
            int luaChon;
            do
            {
                Console.WriteLine("\n===== QUẢN LÝ MƯỢN SÁCH =====");
                Console.WriteLine("1. Nhập thông tin thẻ mượn");
                Console.WriteLine("2. Tìm kiếm sinh viên theo mã số sinh viên");
                Console.WriteLine("3. Hiển thị sinh viên đã đến hạn trả sách");
                Console.WriteLine("4. Thoát");
                Console.Write("Lựa chọn: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        NhapThongTinMuonSach();
                        break;
                    case 2:
                        Console.Write("Nhập mã số sinh viên cần tìm: ");
                        string maSoSinhVien = Console.ReadLine();
                        TimKiemSinhVienTheoMaSo(maSoSinhVien);
                        break;
                    case 3:
                        HienThiSinhVienDenHanTra();
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
            Console.OutputEncoding = System.Text.Encoding.UTF8; 

            QuanLyMuonSach qlm = new QuanLyMuonSach();
            qlm.Menu();
        }
    }
}
