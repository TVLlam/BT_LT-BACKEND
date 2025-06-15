using System;

namespace XuLyVanBan
{
    // Lớp VanBan
    class VanBan
    {
        public string XauKyTu { get; set; }

        // Hàm tạo không đối số
        public VanBan()
        {
            XauKyTu = string.Empty;
        }

        // Hàm tạo có đối số
        public VanBan(string st)
        {
            XauKyTu = st;
        }

        // Phương thức đếm số từ trong xâu
        public int DemSoTu()
        {
            if (string.IsNullOrWhiteSpace(XauKyTu))
                return 0;

            string[] tu = XauKyTu.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return tu.Length;
        }

        // Phương thức đếm số ký tự 'H' (không phân biệt hoa thường)
        public int DemSoKyTuH()
        {
            int dem = 0;
            foreach (char c in XauKyTu)
            {
                if (char.ToLower(c) == 'h')  // Không phân biệt chữ hoa, chữ thường
                {
                    dem++;
                }
            }
            return dem;
        }

        // Phương thức chuẩn hoá xâu
        public string ChuanHoaXau()
        {
            // Loại bỏ khoảng trắng ở đầu và cuối xâu
            string xauChuanHoa = XauKyTu.Trim();

            // Loại bỏ khoảng trắng thừa giữa các từ
            while (xauChuanHoa.Contains("  ")) // Nếu có hai khoảng trắng liên tiếp
            {
                xauChuanHoa = xauChuanHoa.Replace("  ", " ");
            }

            return xauChuanHoa;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Đảm bảo in được tiếng Việt

            VanBan vb = new VanBan();

            int luaChon;
            do
            {
                // Hiển thị menu cho người dùng
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Nhập xâu văn bản");
                Console.WriteLine("2. Đếm số từ trong xâu");
                Console.WriteLine("3. Đếm số ký tự 'H' trong xâu");
                Console.WriteLine("4. Chuẩn hoá xâu");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn tác vụ: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        // Nhập xâu văn bản
                        Console.Write("Nhập xâu văn bản: ");
                        vb.XauKyTu = Console.ReadLine();
                        break;

                    case 2:
                        // Đếm số từ trong xâu
                        int soTu = vb.DemSoTu();
                        Console.WriteLine($"Số từ trong xâu là: {soTu}");
                        break;

                    case 3:
                        // Đếm số ký tự 'H' (không phân biệt chữ hoa và chữ thường)
                        int soKyTuH = vb.DemSoKyTuH();
                        Console.WriteLine($"Số ký tự 'H' trong xâu là: {soKyTuH}");
                        break;

                    case 4:
                        // Chuẩn hoá xâu
                        string xauChuanHoa = vb.ChuanHoaXau();
                        Console.WriteLine($"Xâu sau khi chuẩn hoá: {xauChuanHoa}");
                        break;

                    case 5:
                        // Thoát chương trình
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
