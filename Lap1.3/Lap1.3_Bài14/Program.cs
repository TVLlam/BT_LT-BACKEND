using System;

namespace PhanSoProgram
{
    // Lớp PhanSo để quản lý các phép toán với phân số
    class PhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        // Hàm tạo không đối số
        public PhanSo()
        {
            TuSo = 0;
            MauSo = 1; // Mẫu số mặc định là 1
        }

        // Hàm tạo có đối số
        public PhanSo(int tu, int mau)
        {
            if (mau == 0)
            {
                Console.WriteLine("Mẫu số không thể bằng 0.");
                TuSo = 0;
                MauSo = 1; // Đặt mẫu số mặc định khi mẫu số bằng 0
            }
            else
            {
                TuSo = tu;
                MauSo = mau;
            }
        }

        // Phương thức nhập phân số
        public void NhapPhanSo()
        {
            Console.Write("Nhập tử số: ");
            TuSo = int.Parse(Console.ReadLine());
            Console.Write("Nhập mẫu số: ");
            MauSo = int.Parse(Console.ReadLine());
            if (MauSo == 0)
            {
                Console.WriteLine("Mẫu số không thể bằng 0. Đặt lại mẫu số là 1.");
                MauSo = 1;
            }
        }

        // Phương thức hiển thị phân số
        public void HienThiPhanSo()
        {
            Console.WriteLine($"Phân số: {TuSo}/{MauSo}");
        }

        // Phương thức rút gọn phân số
        public void RutGon()
        {
            int gcd = GCD(TuSo, MauSo); // Tìm ước chung lớn nhất
            TuSo /= gcd;
            MauSo /= gcd;
        }

        // Phương thức tính ước chung lớn nhất (GCD)
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Phương thức cộng hai phân số
        public PhanSo Cong(PhanSo ps)
        {
            int tu = TuSo * ps.MauSo + ps.TuSo * MauSo;
            int mau = MauSo * ps.MauSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }

        // Phương thức trừ hai phân số
        public PhanSo Tru(PhanSo ps)
        {
            int tu = TuSo * ps.MauSo - ps.TuSo * MauSo;
            int mau = MauSo * ps.MauSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }

        // Phương thức nhân hai phân số
        public PhanSo Nhan(PhanSo ps)
        {
            int tu = TuSo * ps.TuSo;
            int mau = MauSo * ps.MauSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }

        // Phương thức chia hai phân số
        public PhanSo Chia(PhanSo ps)
        {
            if (ps.TuSo == 0)
            {
                Console.WriteLine("Không thể chia cho phân số có tử số bằng 0.");
                return new PhanSo(0, 1); // Trả về phân số mặc định nếu chia cho phân số có tử số bằng 0
            }
            int tu = TuSo * ps.MauSo;
            int mau = MauSo * ps.TuSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Đảm bảo in được tiếng Việt

            PhanSo phanSoA = new PhanSo();
            PhanSo phanSoB = new PhanSo();

            // Nhập hai phân số
            Console.WriteLine("Nhập phân số A:");
            phanSoA.NhapPhanSo();
            Console.WriteLine("Nhập phân số B:");
            phanSoB.NhapPhanSo();

            // Hiển thị hai phân số
            Console.WriteLine("\nPhân số A:");
            phanSoA.HienThiPhanSo();
            Console.WriteLine("Phân số B:");
            phanSoB.HienThiPhanSo();

            int luaChon;
            do
            {
                // Menu cho người dùng chọn phép toán
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Tính tổng hai phân số");
                Console.WriteLine("2. Tính hiệu hai phân số");
                Console.WriteLine("3. Tính tích hai phân số");
                Console.WriteLine("4. Tính thương hai phân số");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn tác vụ: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        // Tính tổng hai phân số
                        PhanSo tong = phanSoA.Cong(phanSoB);
                        Console.WriteLine("Tổng hai phân số là:");
                        tong.HienThiPhanSo();
                        break;

                    case 2:
                        // Tính hiệu hai phân số
                        PhanSo hieu = phanSoA.Tru(phanSoB);
                        Console.WriteLine("Hiệu hai phân số là:");
                        hieu.HienThiPhanSo();
                        break;

                    case 3:
                        // Tính tích hai phân số
                        PhanSo tich = phanSoA.Nhan(phanSoB);
                        Console.WriteLine("Tích hai phân số là:");
                        tich.HienThiPhanSo();
                        break;

                    case 4:
                        // Tính thương hai phân số
                        PhanSo thuong = phanSoA.Chia(phanSoB);
                        Console.WriteLine("Thương hai phân số là:");
                        thuong.HienThiPhanSo();
                        break;

                    case 5:
                        // Thoát
                        Console.WriteLine("Thoát khỏi chương trình.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            } while (luaChon != 5);
        }
    }
}
