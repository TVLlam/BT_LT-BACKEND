using System;

public class MaTran
{
    private int soDong;
    private int soCot;
    private double[,] mangHaiChieu;

    // 1. Các hàm tạo
    public MaTran()
    {
        soDong = 1;
        soCot = 1;
        mangHaiChieu = new double[1, 1];
    }

    public MaTran(int n, int m)
    {
        soDong = n;
        soCot = m;
        mangHaiChieu = new double[n, m];
    }

    // 2. Phương thức nhập và hiển thị ma trận
    public void NhapMaTran()
    {
        Console.WriteLine($"Nhập ma trận {soDong}x{soCot}:");
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                Console.Write($"Phần tử [{i},{j}]: ");
                mangHaiChieu[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }

    public void HienThiMaTran()
    {
        Console.WriteLine("Ma trận:");
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                Console.Write($"{mangHaiChieu[i, j],8:F2}");
            }
            Console.WriteLine();
        }
    }

    // 3. Các phương thức tính toán
    public static MaTran Tong(MaTran a, MaTran b)
    {
        if (a.soDong != b.soDong || a.soCot != b.soCot)
        {
            throw new ArgumentException("Hai ma trận không cùng kích thước!");
        }

        MaTran ketQua = new MaTran(a.soDong, a.soCot);
        for (int i = 0; i < a.soDong; i++)
        {
            for (int j = 0; j < a.soCot; j++)
            {
                ketQua.mangHaiChieu[i, j] = a.mangHaiChieu[i, j] + b.mangHaiChieu[i, j];
            }
        }
        return ketQua;
    }

    public static MaTran Hieu(MaTran a, MaTran b)
    {
        if (a.soDong != b.soDong || a.soCot != b.soCot)
        {
            throw new ArgumentException("Hai ma trận không cùng kích thước!");
        }

        MaTran ketQua = new MaTran(a.soDong, a.soCot);
        for (int i = 0; i < a.soDong; i++)
        {
            for (int j = 0; j < a.soCot; j++)
            {
                ketQua.mangHaiChieu[i, j] = a.mangHaiChieu[i, j] - b.mangHaiChieu[i, j];
            }
        }
        return ketQua;
    }

    public static MaTran Tich(MaTran a, MaTran b)
    {
        if (a.soCot != b.soDong)
        {
            throw new ArgumentException("Số cột ma trận A phải bằng số dòng ma trận B!");
        }

        MaTran ketQua = new MaTran(a.soDong, b.soCot);
        for (int i = 0; i < a.soDong; i++)
        {
            for (int j = 0; j < b.soCot; j++)
            {
                ketQua.mangHaiChieu[i, j] = 0;
                for (int k = 0; k < a.soCot; k++)
                {
                    ketQua.mangHaiChieu[i, j] += a.mangHaiChieu[i, k] * b.mangHaiChieu[k, j];
                }
            }
        }
        return ketQua;
    }

    // Phương thức tính thương (nghịch đảo ma trận - đơn giản hóa)
    public static MaTran Thuong(MaTran a, MaTran b)
    {
        // Đơn giản hóa: Thương = A * B^(-1)
        // Trong thực tế cần kiểm tra điều kiện và cài đặt phức tạp hơn
        if (b.soDong != b.soCot)
        {
            throw new ArgumentException("Ma trận B phải là ma trận vuông để tính nghịch đảo!");
        }

        MaTran nghichDaoB = NghichDao(b);
        return Tich(a, nghichDaoB);
    }

    // Phương thức hỗ trợ tính nghịch đảo (đơn giản cho ma trận 2x2)
    private static MaTran NghichDao(MaTran m)
    {
        if (m.soDong != 2 || m.soCot != 2)
        {
            throw new ArgumentException("Chỉ hỗ trợ nghịch đảo ma trận 2x2 trong demo này");
        }

        double dinhThuc = m.mangHaiChieu[0, 0] * m.mangHaiChieu[1, 1] - m.mangHaiChieu[0, 1] * m.mangHaiChieu[1, 0];
        if (dinhThuc == 0)
        {
            throw new ArgumentException("Ma trận không khả nghịch (định thức = 0)");
        }

        MaTran ketQua = new MaTran(2, 2);
        ketQua.mangHaiChieu[0, 0] = m.mangHaiChieu[1, 1] / dinhThuc;
        ketQua.mangHaiChieu[0, 1] = -m.mangHaiChieu[0, 1] / dinhThuc;
        ketQua.mangHaiChieu[1, 0] = -m.mangHaiChieu[1, 0] / dinhThuc;
        ketQua.mangHaiChieu[1, 1] = m.mangHaiChieu[0, 0] / dinhThuc;

        return ketQua;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            // Nhập kích thước ma trận
            Console.Write("Nhập số dòng cho ma trận A và B: ");
            int dong = int.Parse(Console.ReadLine());
            Console.Write("Nhập số cột cho ma trận A và B: ");
            int cot = int.Parse(Console.ReadLine());

            // Tạo và nhập ma trận A, B
            MaTran a = new MaTran(dong, cot);
            MaTran b = new MaTran(dong, cot);

            Console.WriteLine("\nNhập ma trận A:");
            a.NhapMaTran();

            Console.WriteLine("\nNhập ma trận B:");
            b.NhapMaTran();

            // Hiển thị menu
            int luaChon;
            do
            {
                Console.WriteLine("\n===== MENU TÍNH TOÁN MA TRẬN =====");
                Console.WriteLine("1. Tính tổng A + B");
                Console.WriteLine("2. Tính tích A * B");
                Console.WriteLine("3. Tính hiệu A - B");
                Console.WriteLine("4. Tính thương A / B (chỉ hỗ trợ ma trận 2x2)");
                Console.WriteLine("5. Thoát");
                Console.Write("Nhập lựa chọn của bạn: ");

                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        Console.WriteLine("\nTổng A + B:");
                        MaTran.Tong(a, b).HienThiMaTran();
                        break;
                    case 2:
                        Console.WriteLine("\nTích A * B:");
                        MaTran.Tich(a, b).HienThiMaTran();
                        break;
                    case 3:
                        Console.WriteLine("\nHiệu A - B:");
                        MaTran.Hieu(a, b).HienThiMaTran();
                        break;
                    case 4:
                        Console.WriteLine("\nThương A / B:");
                        MaTran.Thuong(a, b).HienThiMaTran();
                        break;
                    case 5:
                        Console.WriteLine("Kết thúc chương trình!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            } while (luaChon != 5);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
    }
}