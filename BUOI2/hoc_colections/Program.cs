//1.ArayList
//Mảng động 
//Cho phép chứa các phần tử khác kiểu dữ liệu
//Có thể chứa các phần tử Null hoặc trùng
//Truy xuất phần tử thông qua chỉ số.

using System.Collections;
using hoc_colections;

ArrayList list = new ArrayList();
// Thêm phần tử vào ArrayList
list.Add("Lam");
list.Add("Hue");
list.Add("B");
list.Add(8);

SinhVien sv = new SinhVien();
sv.MaSV = 1;
sv.HoTen = "Tran Van A";
list.Add(sv);

// TRuy xuất phần tử (thông qua chỉ số)
Console.WriteLine(list[0]); //Lam
// ChÈN phần tử
list.Insert(1, "Anh");
// Xóa phần tử trong Array
//list.Remove("Anh"); // Xóa theo giá trị
list.RemoveAt(1); //Xóa theo chỉ số
// Tìm kiếm
Console.WriteLine(list.IndexOf("Hue"));//Vị trí đầu tiên
Console.WriteLine(list.LastIndexOf("Hue"));//Vị trí đầu tiên
Console.WriteLine(list.Contains("Hue"));//True
//Duyệt các phần tử trong ArrayList
foreach (object item in list)
{
    if (item is SinhVien)
    {
        SinhVien sinhVien = (SinhVien)item;
        Console.WriteLine($"{sinhVien.MaSV}, {sinhVien.HoTen}");
    }
    else
    {
        Console.WriteLine(item);
    }    
} 
    

////Hashtable
////Tập hợp các phân tử
////mỗi phần tử là cặp <key và value>
////Key phải là duy nhất, khác null
////truy xuất phần tử thông qua key

//Hashtable ht = new Hashtable();
////Thêm phần tử 
//ht.Add("Tuan", 10);
//ht.Add(20, 100);
//ht.Add("Anh", 1000);
//ht.Add("Hiep", "Hoai");
////Truy xuất phần tử
//Console.WriteLine(ht["Anh"]); //1000
////Xóa phần tử 
//ht.Remove("Anh"); //xóa theo key
////Duyệt các phần tử
////cách 1: duyệt theo chiều dọc
//ICollection keys = ht.Keys;
//foreach (object key in keys)
//{
//    Console.WriteLine($"{key}, {ht[key]}");
//}    
////Cách 2: duyệt theo chiều ngang
//foreach(DictionaryEntry entry in ht)
//{
//    Console.WriteLine($"{entry.Key}, {entry.Value}");
//}    