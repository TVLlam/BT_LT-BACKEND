using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKhuPho
{
    // Lớp Nguoi để quản lý thông tin cá nhân
    class Nguoi
    {
        public string SoChungMinhNhanDan { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public int NamSinh { get; set; }
        public string NgheNghiep { get; set; }

        // Nhập thông tin cá nhân
        public void Nhap()
        {
            Console.Write("Nhập số chứng minh nhân dân: ");
            SoChungMinhNhanDan = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhập tuổi: ");
            Tuoi = int.Parse(Console.ReadLine());

            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());

            Console.Write("Nhập nghề nghiệp: ");
            NgheNghiep = Console.ReadLine();
        }

        // Hiển thị thông tin cá nhân
        public void HienThi()
        {
            Console.WriteLine($"Số CMND: {SoChungMinhNhanDan}, Họ tên: {HoTen}, Tuổi: {Tuoi}, Năm sinh: {NamSinh}, Nghề nghiệp: {NgheNghiep}");
        }
    }

    // Lớp KhuPho để quản lý các hộ gia đình
    class KhuPho
    {
        public string SoNha { get; set; }
        public List<Nguoi> DanhSachNguoi { get; set; }

        public KhuPho()
        {
            DanhSachNguoi = new List<Nguoi>();
        }

        // Nhập thông tin hộ gia đình
        public void Nhap()
        {
            Console.Write("Nhập số nhà: ");
            SoNha = Console.ReadLine();

            Console.Write("Nhập số thành viên trong hộ: ");
            int soThanhVien = int.Parse(Console.ReadLine());

            for (int i = 0; i < soThanhVien; i++)
            {
                Console.WriteLine($"Nhập thông tin thành viên {i + 1}:");
                Nguoi nguoi = new Nguoi();
                nguoi.Nhap();
                DanhSachNguoi.Add(nguoi);
            }
        }

        // Hiển thị thông tin hộ gia đình
        public void HienThi()
        {
            Console.WriteLine($"Số nhà: {SoNha}");
            foreach (var nguoi in DanhSachNguoi)
            {
                nguoi.HienThi();
            }
        }

        // Tìm kiếm thông tin theo họ tên
        public void TimKiemTheoHoTen(string hoTen)
        {
            Console.WriteLine($"\nTìm kiếm theo họ tên: {hoTen}");
            bool timThay = false;
            foreach (var nguoi in DanhSachNguoi)
            {
                if (nguoi.HoTen.ToLower().Contains(hoTen.ToLower()))
                {
                    nguoi.HienThi();
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy thí sinh có họ tên này.");
            }
        }

        // Tìm kiếm thông tin theo số nhà
        public void TimKiemTheoSoNha(string soNha)
        {
            if (SoNha.Equals(soNha))
            {
                HienThi();
            }
            else
            {
                Console.WriteLine("Không tìm thấy hộ dân với số nhà này.");
            }
        }
    }

    // Lớp QuanLyKhuPho để quản lý danh sách các hộ dân
    class QuanLyKhuPho
    {
        private List<KhuPho> danhSachKhuPho = new List<KhuPho>();

        // Nhập thông tin các hộ dân
        public void NhapThongTinKhuPho()
        {
            Console.Write("Nhập số lượng hộ dân: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thông tin hộ dân thứ {i + 1}:");
                KhuPho khuPho = new KhuPho();
                khuPho.Nhap();
                danhSachKhuPho.Add(khuPho);
            }
        }

        // Hiển thị thông tin tất cả các hộ dân
        public void HienThiTatCaHienThi()
        {
            Console.WriteLine("\n--- DANH SÁCH CÁC HỘ DÂN ---");
            if (danhSachKhuPho.Count == 0)
            {
                Console.WriteLine("Danh sách hộ dân trống.");
            }
            else
            {
                foreach (var khuPho in danhSachKhuPho)
                {
                    khuPho.HienThi();
                }
            }
        }

        // Tìm kiếm hộ dân theo số nhà
        public void TimKiemTheoSoNha(string soNha)
        {
            foreach (var khuPho in danhSachKhuPho)
            {
                khuPho.TimKiemTheoSoNha(soNha);
            }
        }

        // Tìm kiếm hộ dân theo họ tên
        public void TimKiemTheoHoTen(string hoTen)
        {
            foreach (var khuPho in danhSachKhuPho)
            {
                khuPho.TimKiemTheoHoTen(hoTen);
            }
        }

        // Menu chương trình
        public void Menu()
        {
            int luaChon;
            do
            {
                Console.WriteLine("\n===== QUẢN LÝ KHU PHỐ =====");
                Console.WriteLine("1. Nhập thông tin các hộ dân");
                Console.WriteLine("2. Hiển thị thông tin các hộ dân");
                Console.WriteLine("3. Tìm kiếm hộ dân theo số nhà");
                Console.WriteLine("4. Tìm kiếm hộ dân theo họ tên");
                Console.WriteLine("5. Thoát");
                Console.Write("Lựa chọn: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        NhapThongTinKhuPho();
                        break;
                    case 2:
                        HienThiTatCaHienThi();
                        break;
                    case 3:
                        Console.Write("Nhập số nhà cần tìm: ");
                        string soNha = Console.ReadLine();
                        TimKiemTheoSoNha(soNha);
                        break;
                    case 4:
                        Console.Write("Nhập họ tên cần tìm: ");
                        string hoTen = Console.ReadLine();
                        TimKiemTheoHoTen(hoTen);
                        break;
                    case 5:
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

            } while (luaChon != 5);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 

            QuanLyKhuPho qlkp = new QuanLyKhuPho();
            qlkp.Menu();
        }
    }
}
