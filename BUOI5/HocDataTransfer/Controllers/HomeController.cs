using System.Diagnostics;
using System.Net.Http.Headers;
using HocDataTransfer.Models;
using HocTagHelper.Models;
using Microsoft.AspNetCore.Mvc;
using ErrorViewModel = HocDataTransfer.Models.ErrorViewModel;

namespace HocDataTransfer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        static List<Product> products = new List<Product>()
        {
            new Product(){Id= 1, ProductName= "Máy Chiếu", Price= 500},
            new Product(){Id= 2, ProductName="Máy In", Price =700 },
            new Product(){Id= 3, ProductName= "Microsoft", Price=1000 }
        };
        public IActionResult Index()
        {
            //Các cách truyền dữ liệu từ controller sang view
            //1. Sử dụng ViewBag
            ViewBag.message1 = "ViewBag là 1 đối tượng dynamic dùng để truyền dữ liệu từ controller sang view trong cùng 1 request" ;
            //2. Sử dụng ViewData
            ViewData["message2"] = "ViewData là 1 dictionary dùng để truyền dữ liệu từ controller sang view trong cùng 1 request. ở bên view phải thực hiện ép kiểu tường minh";
            //3. Sử dụng TempData
            TempData["message3"] = "TempData là 1 dictionary dùng để truyền dữ liệu từ controller sang view trong nhiều request. ở bên view phải thực hiện ép kiểu tường minh";

            List<string> names = new List<string>()
            {
                "Tuấn", "Bình", "Hải", "Thắng"
            };
            ViewData["names"] = names;
            //4. Sử dụng model
            //- Bên controller: return View(model);
            //- Bên view: @model: khai báo model class
            //            @model: đối tượng chứa dữ liệu nhận được từ Controller
            return View();
            //return RedirectToAction("GetData");
            //5. sử dụng session
        }
        public IActionResult GetData()
        {
   
           return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "123456")
            {
                //Lưu thông tin đăng nhập vào session
                HttpContext.Session.SetString("fullname", "Trần Văn Lâm");
                return RedirectToAction("GetData");
            }
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
