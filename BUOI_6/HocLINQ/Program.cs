using HocLINQ;

int[] numbers = {3, 1, 8, 5, 2, 7, 4, 6 };
////- Query syntax
//var result1 = from n in numbers
//              where n % 2 == 0
//              select n;

////- Method syntax
//var result1 = numbers.Where(n => n % 2 == 0).Select(n => n);
//foreach (var item in result1)
//{
//    Console.Write(item + " ");
//}

List<Brand> brands = new List<Brand>()
{
    new Brand(){BrandId=1,BrandName="Công ty may 10"},
    new Brand(){BrandId=2,BrandName="Công ty CMC"},
    new Brand(){BrandId=3,BrandName="Nhà sách Trí Tuệ"},
    new Brand(){BrandId=4,BrandName="Công ty Xuân Hòa"}
};
List<Product> products = new List<Product>()
{
    new Product(){ProductId=1,ProductName="Laptop Dell",
        Price=15000000,Colors = new string[]{"Trắng","Đen"},BrandId=2},
    new Product(){ProductId=2,ProductName="Áo đồng phục",
        Price=250000,Colors = new string[]{"Trắng","Xanh"},BrandId=1},
    new Product(){ProductId=3,ProductName="Bàn học",
        Price=800000,Colors = new string[]{"Trắng","Nâu"},BrandId=4},
    new Product(){ProductId=4,ProductName="Đèn bàn",
        Price=400000,Colors = new string[]{"Xanh","Hồng"},BrandId=3},
    new Product(){ProductId=5,ProductName="Máy chiếu",
        Price=12000000,Colors = new string[]{"Trắng","Đen"},BrandId=2},
    new Product(){ProductId=6,ProductName="Cặp học sinh",
        Price=600000,Colors = new string[]{"Trắng","Hồng"},BrandId=3},
};

Console.OutputEncoding = System.Text.Encoding.UTF8;

// CÁC TOÁN TỬ TRUY VẤN
// 1. phép chiếu
//- query syntax
//var result = brands.Select (b => b);
//foreach (var item in result)
//{
//    Console.WriteLine(item.BrandName);
//}

//Trả về đối tượng vô danh
////- query syntax
//var result = from p in products
//             select new { MaSP= p.ProductId, TenSP= p.ProductName };
//Method syntax
//var result = products.Select(p => new { MaSP = p.ProductId, TenSP = p.ProductName });
//foreach (var item in result)
//{
//    Console.WriteLine($"{item.MaSP}, { item.TenSP}");
//}    
//

// 2. phép lọc: where
//- query syntax
//var result = from p in products
//             where p.Price > 1000000
//             select p;
//foreach (var item in result)
//{
//    Console.WriteLine($"{item.ProductName}, {item.Price}");
//}
//Method syntax
//var result = products.Where(p => p.Price > 1000000).Select(p => p);
//foreach (var item in result)
//{
//    Console.WriteLine($"{item.ProductName}, {item.Price}");
//}

// 3. phép sắp xếp: orderby
//- query syntax

//var result = from b in brands
//             orderby b.BrandName descending
//             select b;

//Method syntax
//var result = brands.OrderByDescending(b => b.BrandName).Select(b => b);
//foreach (var item in result)
//{
//    Console.WriteLine($"{item.BrandId}, {item.BrandName}");
//}

//4. phép nối: join
////- query syntax
//var result = from p in products
//             join b in brands on p.BrandId equals b.BrandId
//             select new 
//             {
//                 MaSP = p.ProductId,
//                 TenSP = p.ProductName, 
//                 TenTH = b.BrandName
//             };
////Method syntax
//var result = products.Join(brands,
//    p => p.BrandId,
//    b => b.BrandId,
//    (p, b) => new
//    {
//        MaSP = p.ProductId,
//        TenSP = p.ProductName,
//        TenTH = b.BrandName
//    });
//foreach (var item in result)
//{
//    Console.WriteLine($"{item.MaSP}, {item.TenSP}, {item.TenTH}");
//}

// 5. phép nhóm: group by
////- query syntax
//var result = from p in products
//             group p by p.BrandId;

//- Method syntax
//var result = products.GroupBy(p => p.BrandId);
//foreach (var brandGroup in result)
//{
//    Console.WriteLine($"Nhóm sản phẩm của thương hiệu có mã {brandGroup.Key}");
//    foreach (var item in brandGroup)
//    {
//        Console.WriteLine($"- {item.ProductId}, {item.ProductName}");
//    }
//}

//6. Toán tử tổng hợp
//var result = products.Average(p => p.Price); // gía trung bình
//var result1 = products.Count(p => p.Price > 1000000);
//var result2 = products.Max(p => p.Price); // giá cao nhất
//tương tự với MIN, sum
//Console.WriteLine(result);

//7. Toán tử định lượng
////var result = products.All(p => p.Price > 1000000); // kiểm tra tất cả sản phẩm nào giá > 1 triệu không?
//var result = products.Any(p => p.Price > 1000000); // có sản phẩm nào giá > 1 triệu không?
//Console.WriteLine(result);

//8. Toán tử phân vùng
//List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
////var result = list.Skip(4); // bỏ qua 4 phần tử đầu tiên
////var result = list.SkipWhile ( p => p < 7);
////var result = list.Take(3); // lấy 3 phần tử đầu tiên
//var result = list.TakeWhile(p => p < 7); // lấy các phần tử đầu tiên mà < 7
//foreach (var item in result)
//{
//    Console.WriteLine(item + " ");
//}

////9. Toán tử taaph hợp : Distinct, Except, Intersect, Union
//List<int> list1 = new List<int>() { 1, 2, 2, 3, 4 };
//List<int> list2 = new List<int>() { 3, 4, 5, 6 };
////var result = list1.Distinct(); // trả về các kết quả khác nhau trong list1
////var result = list1.Except(list2); // trả về các phần tử trong list1 mà không có trong list2
////var result = list1.Intersect(list2); // trả về các phần tử chung giữa list1 và list2
//var result = list1.Union(list2); // trả về các phần tử khác nhau giữa list1 và list2
//foreach (var item in result)
//{
//    Console.Write(item + " ");
//}

//10. Toán tử phần tử
//var result = products.First (p => p.BrandID == 3);
//var result = products.Last (p => p.BrandId == 3);
//var result = products.Single( p => p.ProductId == 4); 

//var result = products.FirstOrDefault(p => p.BrandId == 3);