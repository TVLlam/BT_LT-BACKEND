using System;
using System.Collections.Generic;

namespace QLPTGT
{
    // Lớp PTGT - Lớp cơ sở cho các loại phương tiện
    class PTGT
    {
        public string HangSanXuat { get; set; }
        public int NamSanXuat { get; set; }
        public double GiaBan { get; set; }
        public string Mau { get; set; }

        // Phương thức nhập thông tin chung của phương tiện
        public void NhapPTGT()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Nhập hãng sản xuất: ");
            HangSanXuat = Console.ReadLine();
            Console.Write("Nhập năm sản xuất: ");
            NamSanXuat = int.Parse(Console.ReadLine());
            Console.Write("Nhập giá bán: ");
            GiaBan = double.Parse(Console.ReadLine());
            Console.Write("Nhập màu sắc: ");
            Mau = Console.ReadLine();
        }

        // Phương thức hiển thị thông tin phương tiện
        public void HienThiPTGT()
        {
            Console.WriteLine($"Hãng sản xuất: {HangSanXuat}");
            Console.WriteLine($"Năm sản xuất: {NamSanXuat}");
            Console.WriteLine($"Giá bán: {GiaBan} VND");
            Console.WriteLine($"Màu: {Mau}");
        }
    }

    // Lớp OTo kế thừa từ PTGT
    class OTo : PTGT
    {
        public int SoChoNgoi { get; set; }
        public string KieuDongCo { get; set; }

        // Phương thức nhập thông tin ô tô
        public void NhapOTo()
        {
            NhapPTGT();
            Console.Write("Nhập số chỗ ngồi: ");
            SoChoNgoi = int.Parse(Console.ReadLine());
            Console.Write("Nhập kiểu động cơ: ");
            KieuDongCo = Console.ReadLine();
        }

        // Phương thức hiển thị thông tin ô tô
        public void HienThiOTo()
        {
            HienThiPTGT();
            Console.WriteLine($"Số chỗ ngồi: {SoChoNgoi}");
            Console.WriteLine($"Kiểu động cơ: {KieuDongCo}");
        }
    }

    // Lớp XeMay kế thừa từ PTGT
    class XeMay : PTGT
    {
        public double CongSuat { get; set; }

        // Phương thức nhập thông tin xe máy
        public void NhapXeMay()
        {
            NhapPTGT();
            Console.Write("Nhập công suất (kw): ");
            CongSuat = double.Parse(Console.ReadLine());
        }

        // Phương thức hiển thị thông tin xe máy
        public void HienThiXeMay()
        {
            HienThiPTGT();
            Console.WriteLine($"Công suất: {CongSuat} kw");
        }
    }

    // Lớp XeTai kế thừa từ PTGT
    class XeTai : PTGT
    {
        public double TrongTai { get; set; }

        // Phương thức nhập thông tin xe tải
        public void NhapXeTai()
        {
            NhapPTGT();
            Console.Write("Nhập trọng tải (tấn): ");
            TrongTai = double.Parse(Console.ReadLine());
        }

        // Phương thức hiển thị thông tin xe tải
        public void HienThiXeTai()
        {
            HienThiPTGT();
            Console.WriteLine($"Trọng tải: {TrongTai} tấn");
        }
    }

    // Lớp quản lý phương tiện giao thông
    class QLPTGT
    {
        private List<PTGT> dsPTGT = new List<PTGT>();

        // Phương thức nhập đăng ký phương tiện
        public void NhapDangKyPTGT()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Nhập loại phương tiện (1: Ô tô, 2: Xe máy, 3: Xe tải): ");
            int loaiPT = int.Parse(Console.ReadLine());

            PTGT ptgt = null;

            switch (loaiPT)
            {
                case 1:
                    OTo oto = new OTo();
                    oto.NhapOTo();
                    ptgt = oto;
                    break;
                case 2:
                    XeMay xeMay = new XeMay();
                    xeMay.NhapXeMay();
                    ptgt = xeMay;
                    break;
                case 3:
                    XeTai xeTai = new XeTai();
                    xeTai.NhapXeTai();
                    ptgt = xeTai;
                    break;
                default:
                    Console.WriteLine("Loại phương tiện không hợp lệ.");
                    return;
            }

            dsPTGT.Add(ptgt);
        }

        // Phương thức tìm kiếm phương tiện theo màu
        public void TimKiemTheoMau(string mau)
        {
            foreach (var ptgt in dsPTGT)
            {
                if (ptgt.Mau.Equals(mau, StringComparison.OrdinalIgnoreCase))
                {
                    ptgt.HienThiPTGT();
                    Console.WriteLine();
                }
            }
        }

        // Phương thức tìm kiếm phương tiện theo năm sản xuất
        public void TimKiemTheoNam(int nam)
        {
            foreach (var ptgt in dsPTGT)
            {
                if (ptgt.NamSanXuat == nam)
                {
                    ptgt.HienThiPTGT();
                    Console.WriteLine();
                }
            }
        }

        // Phương thức hiển thị tất cả phương tiện
        public void HienThiTatCaPTGT()
        {
            foreach (var ptgt in dsPTGT)
            {
                ptgt.HienThiPTGT();
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            QLPTGT qlPTGT = new QLPTGT();
            int luaChon;

            do
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8; 
                Console.InputEncoding = System.Text.Encoding.UTF8;

                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Nhập đăng ký phương tiện");
                Console.WriteLine("2. Tìm phương tiện theo màu");
                Console.WriteLine("3. Tìm phương tiện theo năm sản xuất");
                Console.WriteLine("4. Hiển thị tất cả phương tiện");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        qlPTGT.NhapDangKyPTGT();
                        break;
                    case 2:
                        Console.Write("Nhập màu cần tìm: ");
                        string mau = Console.ReadLine();
                        qlPTGT.TimKiemTheoMau(mau);
                        break;
                    case 3:
                        Console.Write("Nhập năm sản xuất cần tìm: ");
                        int nam = int.Parse(Console.ReadLine());
                        qlPTGT.TimKiemTheoNam(nam);
                        break;
                    case 4:
                        qlPTGT.HienThiTatCaPTGT();
                        break;
                    case 5:
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            } while (luaChon != 5);
        }
    }
}
