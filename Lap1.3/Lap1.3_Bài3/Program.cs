using System;
using System.Collections.Generic;
using System.Text;

namespace ThiSinhDaiHoc
{
    // Lớp cơ sở ThiSinh
    class ThiSinh
    {
        public string SoBaoDanh { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string UuTien { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhập số báo danh: ");
            SoBaoDanh = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhập địa chỉ: ");
            DiaChi = Console.ReadLine();

            Console.Write("Nhập ưu tiên: ");
            UuTien = Console.ReadLine();
        }

        public virtual void HienThi()
        {
            Console.Write($"Số báo danh: {SoBaoDanh}, Họ tên: {HoTen}, Địa chỉ: {DiaChi}, Ưu tiên: {UuTien}");
        }

        public virtual bool TrúngTuyen()
        {
            return false; // Lớp cơ sở không có tiêu chí trúng tuyển
        }
    }

    // Lớp ThiSinhKhoiA
    class ThiSinhKhoiA : ThiSinh
    {
        public float DiemToan { get; set; }
        public float DiemLy { get; set; }
        public float DiemHoa { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập điểm Toán: ");
            DiemToan = float.Parse(Console.ReadLine());

            Console.Write("Nhập điểm Lý: ");
            DiemLy = float.Parse(Console.ReadLine());

            Console.Write("Nhập điểm Hóa: ");
            DiemHoa = float.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($", Điểm Toán: {DiemToan}, Điểm Lý: {DiemLy}, Điểm Hóa: {DiemHoa}");
        }

        public override bool TrúngTuyen()
        {
            return (DiemToan + DiemLy + DiemHoa) >= 15; // Điểm chuẩn khối A là 15
        }
    }

    // Lớp ThiSinhKhoiB
    class ThiSinhKhoiB : ThiSinh
    {
        public float DiemToan { get; set; }
        public float DiemHoa { get; set; }
        public float DiemSinh { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập điểm Toán: ");
            DiemToan = float.Parse(Console.ReadLine());

            Console.Write("Nhập điểm Hóa: ");
            DiemHoa = float.Parse(Console.ReadLine());

            Console.Write("Nhập điểm Sinh: ");
            DiemSinh = float.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($", Điểm Toán: {DiemToan}, Điểm Hóa: {DiemHoa}, Điểm Sinh: {DiemSinh}");
        }

        public override bool TrúngTuyen()
        {
            return (DiemToan + DiemHoa + DiemSinh) >= 16; // Điểm chuẩn khối B là 16
        }
    }

    // Lớp ThiSinhKhoiC
    class ThiSinhKhoiC : ThiSinh
    {
        public float DiemVan { get; set; }
        public float DiemSu { get; set; }
        public float DiemDia { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập điểm Văn: ");
            DiemVan = float.Parse(Console.ReadLine());

            Console.Write("Nhập điểm Sử: ");
            DiemSu = float.Parse(Console.ReadLine());

            Console.Write("Nhập điểm Địa: ");
            DiemDia = float.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($", Điểm Văn: {DiemVan}, Điểm Sử: {DiemSu}, Điểm Địa: {DiemDia}");
        }

        public override bool TrúngTuyen()
        {
            return (DiemVan + DiemSu + DiemDia) >= 13.5; // Điểm chuẩn khối C là 13.5
        }
    }

    // Lớp quản lý Tuyển Sinh
    class TuyenSinh
    {
        private List<ThiSinh> danhSach = new List<ThiSinh>();

        public void NhapThongTinThiSinh()
        {
            Console.WriteLine("\n1. Thí sinh thi khối A\n2. Thí sinh thi khối B\n3. Thí sinh thi khối C");
            Console.Write("Chọn loại thí sinh: ");
            int chon = int.Parse(Console.ReadLine());

            ThiSinh ts = null;
            switch (chon)
            {
                case 1: ts = new ThiSinhKhoiA(); break;
                case 2: ts = new ThiSinhKhoiB(); break;
                case 3: ts = new ThiSinhKhoiC(); break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    return;
            }

            ts.Nhap();
            danhSach.Add(ts);
        }

        public void HienThiThongTinThiSinh()
        {
            Console.WriteLine("\n--- DANH SÁCH THÍ SINH ĐÃ TRÚNG TUYỂN ---");
            bool timThay = false;
            foreach (var ts in danhSach)
            {
                if (ts.TrúngTuyen())
                {
                    ts.HienThi();
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Không có thí sinh nào trúng tuyển.");
            }
        }

        public void TimKiemTheoSoBaoDanh()
        {
            Console.Write("Nhập số báo danh cần tìm: ");
            string sbd = Console.ReadLine();
            bool timThay = false;

            foreach (var ts in danhSach)
            {
                if (ts.SoBaoDanh.Equals(sbd))
                {
                    ts.HienThi();
                    timThay = true;
                    break;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy thí sinh với số báo danh này.");
            }
        }

        public void Menu()
        {
            int luaChon;
            do
            {
                Console.WriteLine("\n===== QUẢN LÝ TUYỂN SINH =====");
                Console.WriteLine("1. Nhập thông tin thí sinh");
                Console.WriteLine("2. Hiển thị thông tin thí sinh đã trúng tuyển");
                Console.WriteLine("3. Tìm kiếm thí sinh theo số báo danh");
                Console.WriteLine("4. Thoát");
                Console.Write("Lựa chọn: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        NhapThongTinThiSinh();
                        break;
                    case 2:
                        HienThiThongTinThiSinh();
                        break;
                    case 3:
                        TimKiemTheoSoBaoDanh();
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

            TuyenSinh ts = new TuyenSinh();
            ts.Menu();
        }
    }
}
