using Microsoft.AspNetCore.Mvc;
using Bai_Tap_Lap3.Models;

namespace Bai_Tap_Lap3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
            // Tạo sản phẩm mẫu
            var product = new Product
            {
                Id = 1,
                Name = "Laptop Dell XPS 13",
                Price = 2000.00m
            };
            return View(product);
        }
    }
}