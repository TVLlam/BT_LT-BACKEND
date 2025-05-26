using System;

namespace SoPhucProgram
{
    // Lớp SoPhuc
    class SoPhuc
    {
        public double PhanThuc { get; set; }
        public double PhanAo { get; set; }

        // Hàm tạo không đối số
        public SoPhuc()
        {
            PhanThuc = 0;
            PhanAo = 0;
        }

        // Hàm tạo có đối số
        public SoPhuc(double a, double b)
        {
            PhanThuc = a;
            PhanAo = b;
        }

        // Phương thức nhập số phức
        public void NhapSoPhuc()
        {
            Console.Write("Nhập phần thực: ");
            PhanThuc = double.Parse(Console.ReadLine());
            Console.Write("Nhập phần ảo: ");
            PhanAo = double.Parse(Console.ReadLine());
        }

        // Phương thức hiển thị số phức
        public void HienThiSoPhuc()
        {
            if (PhanAo >= 0)
                Console.WriteLine($"Số phức: {PhanThuc} + {PhanAo}i");
            else
                Console.WriteLine($"Số phức: {PhanThuc} - {Math.Abs(PhanAo)}i");
        }

        // Phương thức cộng hai số phức
        public SoPhuc Cong(SoPhuc sp)
        {
            double a = PhanThuc + sp.PhanThuc;
            double b = PhanAo + sp.PhanAo;
            return new SoPhuc(a, b);
        }

        // Phương thức nhân hai số phức
        public SoPhuc Nhan(SoPhuc sp)
        {
            double a = PhanThuc * sp.PhanThuc - PhanAo * sp.PhanAo;
            double b = PhanThuc * sp.PhanAo + PhanAo * sp.PhanThuc;
            return new SoPhuc(a, b);
        }

        // Phương thức chia hai số phức
        public SoPhuc Chia(SoPhuc sp)
        {
            double denominator = sp.PhanThuc * sp.PhanThuc + sp.PhanAo * sp.PhanAo;
            if (denominator == 0)
            {
                Console.WriteLine("Không thể chia cho số phức có mẫu số bằng 0.");
                return new SoPhuc(0, 0); // Trả về số phức mặc định nếu mẫu số bằng 0
            }
            double a = (PhanThuc * sp.PhanThuc + PhanAo * sp.PhanAo) / denominator;
            double b = (PhanAo * sp.PhanThuc - PhanThuc * sp.PhanAo) / denominator;
            return new SoPhuc(a, b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Đảm bảo in được tiếng Việt

            SoPhuc soPhucA = new SoPhuc();
            SoPhuc soPhucB = new SoPhuc();

            // Nhập hai số phức
            Console.WriteLine("Nhập số phức A:");
            soPhucA.NhapSoPhuc();

            Console.WriteLine("Nhập số phức B:");
            soPhucB.NhapSoPhuc();

            // Hiển thị hai số phức
            Console.WriteLine("\nSố phức A:");
            soPhucA.HienThiSoPhuc();
            Console.WriteLine("Số phức B:");
            soPhucB.HienThiSoPhuc();

            int luaChon;
            do
            {
                // Menu cho người dùng chọn phép toán
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Tính tổng hai số phức");
                Console.WriteLine("2. Tính hiệu hai số phức");
                Console.WriteLine("3. Tính tích hai số phức");
                Console.WriteLine("4. Tính thương hai số phức");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn tác vụ: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        // Tính tổng hai số phức
                        SoPhuc tong = soPhucA.Cong(soPhucB);
                        Console.WriteLine("Tổng hai số phức là:");
                        tong.HienThiSoPhuc();
                        break;

                    case 2:
                        // Tính hiệu hai số phức
                        SoPhuc hieu = soPhucA.Cong(new SoPhuc(-soPhucB.PhanThuc, -soPhucB.PhanAo));
                        Console.WriteLine("Hiệu hai số phức là:");
                        hieu.HienThiSoPhuc();
                        break;

                    case 3:
                        // Tính tích hai số phức
                        SoPhuc tich = soPhucA.Nhan(soPhucB);
                        Console.WriteLine("Tích hai số phức là:");
                        tich.HienThiSoPhuc();
                        break;

                    case 4:
                        // Tính thương hai số phức
                        SoPhuc thuong = soPhucA.Chia(soPhucB);
                        Console.WriteLine("Thương hai số phức là:");
                        thuong.HienThiSoPhuc();
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
