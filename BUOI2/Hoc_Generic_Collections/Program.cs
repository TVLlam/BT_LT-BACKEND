//1.List<T>: tương tự như ArrayList nhưng các phần tử 
// Phải được xác định kiểu dữ liệu trước
//List<string> list = new List<string>();
//list.Add("Dao");
//list.Add("Man");
//list.Add("Mo");
// các phương thức thì giống với arraylist
// c# 3.0 có thể viết lại như sau:
using Hoc_Generic_Collections;

List<string> list = new List<string>()
{
    "Dao", "Man", "Mo"
};

//List<KhachHang> listKH = new List<KhachHang>();
//listKH.Add(new KhachHang() { MaKH= 1, HoTen= "NGuyen Thi Lien"});
//listKH.Add(new KhachHang() { MaKH = 2, HoTen = "NGuyen Thi Ba" });
//listKH.Add(new KhachHang() { MaKH = 3, HoTen = "NGuyen Thi He" });

//C# 3.0 có thể viết lại
List<KhachHang> listKH = new List<KhachHang>();
{
    new KhachHang() { MaKH = 1, HoTen = "NGuyen Thi Lien" };
    new KhachHang() { MaKH = 2, HoTen = "NGuyen Thi Ba" };
    new KhachHang() { MaKH = 3, HoTen = "NGuyen Thi He" };

}
////2. Dictionary<k,v> tương tự như hashtable nhưng k, v phải được xác định kiểu dữ liệu trước
//Dictionary<int, string> dic = new Dictionary<int, string>();
//dic.Add(10, "Tuấn");
//dic.Add(20, "Hoàng");

//có thể viết lại như sau
Dictionary<int, string> dic = new Dictionary<int, string>()
{
    { 10, "Tuan" }, {20, "Hoàng" }
};
