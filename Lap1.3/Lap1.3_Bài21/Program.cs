using System;
using System.Collections.Generic;
using System.Text;

namespace Bai21
{
    class HocSinh
    {
        public string HoTen { get; set; }
        public string GioiTinh { get; set; } // "nam" hoặc "nữ"
        public double Toan { get; set; }
        public double Ly { get; set; }
        public double Hoa { get; set; }
        public double MonThem { get; set; } // Kỹ thuật (nam) hoặc Nữ công (nữ)

        public void Nhap()
        {
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập giới tính (nam/nữ): ");
            GioiTinh = Console.ReadLine().Trim().ToLower();
            Console.Write("Nhập điểm Toán: ");
            Toan = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Lý: ");
            Ly = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Hóa: ");
            Hoa = double.Parse(Console.ReadLine());
            if (GioiTinh == "nam")
            {
                Console.Write("Nhập điểm môn Kỹ thuật: ");
                MonThem = double.Parse(Console.ReadLine());
            }
            else if (GioiTinh == "nữ")
            {
                Console.Write("Nhập điểm môn Nữ công: ");
                MonThem = double.Parse(Console.ReadLine());
            }
            else
            {
                MonThem = 0;
            }
        }

        public void HienThi()
        {
            Console.WriteLine("Họ tên: " + HoTen);
            Console.WriteLine("Giới tính: " + GioiTinh);
            Console.WriteLine("Điểm Toán: " + Toan);
            Console.WriteLine("Điểm Lý: " + Ly);
            Console.WriteLine("Điểm Hóa: " + Hoa);
            if (GioiTinh == "nam")
                Console.WriteLine("Điểm môn Kỹ thuật: " + MonThem);
            else if (GioiTinh == "nữ")
                Console.WriteLine("Điểm môn Nữ công: " + MonThem);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;

            List<HocSinh> dsHocSinh = new List<HocSinh>();
            Console.Write("Nhập số lượng học sinh: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập thông tin học sinh thứ {i + 1}:");
                HocSinh hs = new HocSinh();
                hs.Nhap();
                dsHocSinh.Add(hs);
            }

            // 2. Hiển thị thông tin những học sinh nam có điểm môn Kỹ thuật không nhỏ hơn 8
            Console.WriteLine("\nCác học sinh nam có điểm môn Kỹ thuật ≥ 8:");
            foreach (var hs in dsHocSinh)
            {
                if (hs.GioiTinh == "nam" && hs.MonThem >= 8)
                {
                    hs.HienThi();
                    Console.WriteLine();
                }
            }

            // 3. In số liệu: học sinh nam trước rồi đến học sinh nữ
            Console.WriteLine("\nDanh sách học sinh (nam trước, nữ sau):");
            Console.WriteLine("\n--- Học sinh nam ---");
            foreach (var hs in dsHocSinh)
            {
                if (hs.GioiTinh == "nam")
                {
                    hs.HienThi();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n--- Học sinh nữ ---");
            foreach (var hs in dsHocSinh)
            {
                if (hs.GioiTinh == "nữ")
                {
                    hs.HienThi();
                    Console.WriteLine();
                }
            }
        }
    }
}
