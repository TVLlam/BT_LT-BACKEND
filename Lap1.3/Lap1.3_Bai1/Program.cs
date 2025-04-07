using System;
using System.Collections.Generic;
using System.Text;

namespace QLCB
{
    // Lớp cơ sở: CanBo
    class CanBo
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());

            Console.Write("Nhập giới tính: ");
            GioiTinh = Console.ReadLine();

            Console.Write("Nhập địa chỉ: ");
            DiaChi = Console.ReadLine();
        }

        public virtual void HienThi()
        {
            Console.Write($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, Giới tính: {GioiTinh}, Địa chỉ: {DiaChi}");
        }
    }

    // Lớp Công Nhân
    class CongNhan : CanBo
    {
        public int Bac { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập bậc (VD: 3 cho bậc 3/7): ");
            Bac = int.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($", Bậc: {Bac}/7");
        }
    }

    // Lớp Kỹ Sư
    class KySu : CanBo
    {
        public string NganhDaoTao { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập ngành đào tạo: ");
            NganhDaoTao = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($", Ngành đào tạo: {NganhDaoTao}");
        }
    }

    // Lớp Nhân Viên
    class NhanVien : CanBo
    {
        public string CongViec { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập công việc: ");
            CongViec = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($", Công việc: {CongViec}");
        }
    }

    // Lớp quản lý cán bộ
    class QLCB
    {
        private List<CanBo> danhSach = new List<CanBo>();

        public void NhapThongTinMoi()
        {
            Console.WriteLine("\n1. Công nhân\n2. Kỹ sư\n3. Nhân viên");
            Console.Write("Chọn loại cán bộ muốn nhập: ");
            int chon = int.Parse(Console.ReadLine());

            CanBo cb = null;

            switch (chon)
            {
                case 1:
                    cb = new CongNhan();
                    break;
                case 2:
                    cb = new KySu();
                    break;
                case 3:
                    cb = new NhanVien();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    return;
            }

            cb.Nhap();
            danhSach.Add(cb);
        }

        public void TimKiemTheoTen()
        {
            Console.Write("Nhập họ tên cần tìm: ");
            string ten = Console.ReadLine();
            bool timThay = false;

            foreach (var cb in danhSach)
            {
                if (cb.HoTen.Equals(ten, StringComparison.OrdinalIgnoreCase))
                {
                    cb.HienThi();
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy cán bộ nào!");
            }
        }

        public void HienThiDanhSach()
        {
            Console.WriteLine("\n--- DANH SÁCH CÁN BỘ ---");
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng.");
                return;
            }

            foreach (var cb in danhSach)
            {
                cb.HienThi();
            }
        }

        public void Menu()
        {
            int luaChon;
            do
            {
                Console.WriteLine("\n===== QUẢN LÝ CÁN BỘ =====");
                Console.WriteLine("1. Nhập cán bộ mới");
                Console.WriteLine("2. Tìm kiếm theo họ tên");
                Console.WriteLine("3. Hiển thị danh sách cán bộ");
                Console.WriteLine("4. Thoát");
                Console.Write("Lựa chọn: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        NhapThongTinMoi();
                        break;
                    case 2:
                        TimKiemTheoTen();
                        break;
                    case 3:
                        HienThiDanhSach();
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

    // Hàm Main
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 

            QLCB qlcb = new QLCB();
            qlcb.Menu();
        }
    }
}
