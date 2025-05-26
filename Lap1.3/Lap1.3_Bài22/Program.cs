using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Bai22
{
    class HocSinh
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public double TongDiem { get; set; }

        public void Nhap()
        {
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhập tổng điểm: ");
            TongDiem = double.Parse(Console.ReadLine());
        }

        public void HienThi()
        {
            // Chuyển các chữ cái đầu của họ tên thành chữ hoa
            TextInfo ti = new CultureInfo("vi-VN", false).TextInfo;
            string hoTenChuan = ti.ToTitleCase(HoTen.ToLower());
            Console.WriteLine($"Họ tên: {hoTenChuan}, Năm sinh: {NamSinh}, Tổng điểm: {TongDiem}");
        }
    }

    class SoSanhHocSinh : IComparer<HocSinh>
    {
        public int Compare(HocSinh a, HocSinh b)
        {
            // Sắp xếp theo tổng điểm giảm dần
            int cmp = b.TongDiem.CompareTo(a.TongDiem);
            if (cmp == 0)
                // Nếu tổng điểm bằng nhau thì sắp xếp theo năm sinh tăng dần (năm nhỏ đứng trước)
                return a.NamSinh.CompareTo(b.NamSinh);
            return cmp;
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

            // Sắp xếp danh sách theo tổng điểm giảm dần và nếu bằng nhau thì năm sinh nhỏ hơn đứng trước
            dsHocSinh.Sort(new SoSanhHocSinh());

            // Hiển thị danh sách theo dạng bảng
            Console.WriteLine("\nDanh sách học sinh sau khi sắp xếp:");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("| Họ tên                         | Năm sinh | Tổng điểm |");
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (var hs in dsHocSinh)
            {
                // Chuyển chữ cái đầu của họ tên thành chữ hoa
                TextInfo ti = new CultureInfo("vi-VN", false).TextInfo;
                string hoTenChuan = ti.ToTitleCase(hs.HoTen.ToLower());
                Console.WriteLine($"| {hoTenChuan,-30} | {hs.NamSinh,-8} | {hs.TongDiem,-10:F1} |");
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
