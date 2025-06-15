//static int TinhTong (int x, int y)
//{
//    return x + y;
//}
static void LoiChao (string name)
{
    Console.WriteLine("Xin Chào: "+name);
}
//2. Khởi tạo
//TinhToan tt = TinhTong;
//Func<int, int, int> tt = TinhTong; //viết tính tổng ngay tại đây
////Phương thức nặc danh (anonymous method) là khối code không có tên, được khai báo bằng từ khóa delegate
//Func<int, int, int> tt = delegate (int x, int y)
//{
//    return x + y;
//};


// Biểu thức Lambda: Là cách viết rút gọn của phương thức nặc danh
//Func<int, int, int> tt = delegate (int x, int y){ return x + y;}; B1
//Func<int, int, int> tt = (int x, int y)=>{ return x + y;}; B2
//Func<int, int, int> tt = (int x, int y)=> x + y; B3
Func<int, int, int> tt = (x, y)=> x + y; //Kết quả
//HienThi ht = LoiChao;
Action<string> ht =LoiChao;
//3.Thực thi
Console.WriteLine("Tong la: " +tt (3,4));
ht("Lam");
//1.Khai báo delegates
public delegate int TinhToan (int a, int b);
public delegate void HienThi(string s);

