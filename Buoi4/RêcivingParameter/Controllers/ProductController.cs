using Microsoft.AspNetCore.Mvc;
using RêcivingParameter.Models;

namespace ReceivingParameter.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product () {ProductId=1, ProductName="Laptop Dell", Price =2000},
            new Product () {ProductId=2, ProductName="Máy Chiếu", Price= 1200 },
            new Product () {ProductId=3, ProductName="Điều Hòa", Price= 800 }
            };
        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        //Tiếp nhận tham số
        ////Cách 1: sử dụng Request
        //public IActionResult Save()
        //{
        //    Product product = new Product();
        //    product.ProductId = int.Parse(Request.Form["ProductId"].ToString());
        //    product.ProductName = Request.Form["productName"];
        //    product.Price = double.Parse(Request.Form["price"].ToString());
        //    products.Add(product);
        //    return RedirectToAction("Index");
        //}

        //Cách 2: sử dụng IformCollection

        //public IActionResult Save(IFormCollection form)
        //{
        //    Product product = new Product();
        //    product.ProductId = int.Parse(form["productId"].ToString());
        //    product.ProductName = form["productName"];
        //    product.Price = double.Parse(form["price"].ToString());
        //    products.Add(product);
        //    return RedirectToAction("Index");
        //}

        ////Cách 3: Sử dụng đối số của action, chỉ nhận tham số trùng tên
        //public IActionResult Save(string productId, string productName, string price)
        //{
        //    Product product = new Product();
        //    product.ProductId = int.Parse(productId);
        //    product.ProductName = productName;
        //    product.Price = double.Parse(price);
        //    products.Add(product);
        //    return RedirectToAction("Index");
        //}

        //Cách 4: sử dụng model
        //- Tạo lớp model chưa các thuộc tính trùng tên với các tham số 
        //- Tạo lớp model để làm đối số của action

        public IActionResult Save(Product product)
        {
            products.Add(product);
            return RedirectToAction("Index");
        }
    }
}
