using System;
using System.Collections.Generic;
using System.Text;

namespace ThuVien
{
    // Lớp cơ sở
    class TaiLieu
    {
        public string MaTaiLieu { get; set; }
        public string TenNhaXuatBan { get; set; }
        public int SoBanPhatHanh { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhập mã tài liệu: ");
            MaTaiLieu = Console.ReadLine();

            Console.Write("Nhập tên nhà xuất bản: ");
            TenNhaXuatBan = Console.ReadLine();

            Console.Write("Nhập số bản phát hành: ");
            SoBanPhatHanh = int.Parse(Console.ReadLine());
        }

        public virtual void HienThi()
        {
            Console.Write($"Mã: {MaTaiLieu}, NXB: {TenNhaXuatBan}, Số bản: {SoBanPhatHanh}");
        }

        public virtual string LoaiTaiLieu()
        {
            return "Tài liệu";
        }
    }

    class Sach : TaiLieu
    {
        public string TenTacGia { get; set; }
        public int SoTrang { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập tên tác giả: ");
            TenTacGia = Console.ReadLine();

            Console.Write("Nhập số trang: ");
            SoTrang = int.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($", Tác giả: {TenTacGia}, Số trang: {SoTrang}");
        }

        public override string LoaiTaiLieu()
        {
            return "Sách";
        }
    }

    class TapChi : TaiLieu
    {
        public int SoPhatHanh { get; set; }
        public int ThangPhatHanh { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập số phát hành: ");
            SoPhatHanh = int.Parse(Console.ReadLine());

            Console.Write("Nhập tháng phát hành: ");
            ThangPhatHanh = int.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($", Số phát hành: {SoPhatHanh}, Tháng: {ThangPhatHanh}");
        }

        public override string LoaiTaiLieu()
        {
            return "Tạp chí";
        }
    }

    class Bao : TaiLieu
    {
        public string NgayPhatHanh { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập ngày phát hành (dd/mm/yyyy): ");
            NgayPhatHanh = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($", Ngày phát hành: {NgayPhatHanh}");
        }

        public override string LoaiTaiLieu()
        {
            return "Báo";
        }
    }

    class QuanLyTaiLieu
    {
        private List<TaiLieu> danhSach = new List<TaiLieu>();

        public void NhapTaiLieuMoi()
        {
            Console.WriteLine("\n1. Sách\n2. Tạp chí\n3. Báo");
            Console.Write("Chọn loại tài liệu: ");
            int chon = int.Parse(Console.ReadLine());

            TaiLieu tl = null;
            switch (chon)
            {
                case 1: tl = new Sach(); break;
                case 2: tl = new TapChi(); break;
                case 3: tl = new Bao(); break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    return;
            }

            tl.Nhap();
            danhSach.Add(tl);
        }

        public void HienThiTatCa()
        {
            Console.WriteLine("\n--- DANH SÁCH TÀI LIỆU ---");
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            foreach (var tl in danhSach)
            {
                tl.HienThi();
            }
        }

        public void TimKiemTheoLoai()
        {
            Console.WriteLine("\nTìm theo loại tài liệu:");
            Console.WriteLine("1. Sách\n2. Tạp chí\n3. Báo");
            Console.Write("Chọn loại: ");
            int chon = int.Parse(Console.ReadLine());

            string loai = chon == 1 ? "Sách" : chon == 2 ? "Tạp chí" : chon == 3 ? "Báo" : "";

            if (loai == "")
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                return;
            }

            Console.WriteLine($"\n--- DANH SÁCH {loai.ToUpper()} ---");
            bool timThay = false;
            foreach (var tl in danhSach)
            {
                if (tl.LoaiTaiLieu() == loai)
                {
                    tl.HienThi();
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine($"Không có tài liệu nào thuộc loại {loai}");
            }
        }

        public void Menu()
        {
            int chon;
            do
            {
                Console.WriteLine("\n===== QUẢN LÝ TÀI LIỆU =====");
                Console.WriteLine("1. Nhập tài liệu mới");
                Console.WriteLine("2. Hiển thị tất cả tài liệu");
                Console.WriteLine("3. Tìm kiếm theo loại");
                Console.WriteLine("4. Thoát");
                Console.Write("Lựa chọn: ");
                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1: NhapTaiLieuMoi(); break;
                    case 2: HienThiTatCa(); break;
                    case 3: TimKiemTheoLoai(); break;
                    case 4: Console.WriteLine("Thoát chương trình."); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }

            } while (chon != 4);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 

            QuanLyTaiLieu ql = new QuanLyTaiLieu();
            ql.Menu();
        }
    }
}
