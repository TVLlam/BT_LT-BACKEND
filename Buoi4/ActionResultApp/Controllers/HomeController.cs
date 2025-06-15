using System.Diagnostics;
using ActionResultApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionResultApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        public IActionResult GetData()
        {
            return View();
        }

        // RedirectResult: chuyển hướng đến URL khác, hàm sử dụng là Redirect()

        public RedirectResult RedirectToGetData()
        {
            return Redirect("/Home/GetData");
        }
        // RedirectToActionResult: chuyển hướng đến Action khác trong Controller, hàm sử dụng là RedirectToAction()
        public RedirectToActionResult RedirectToIndex()
        {
            return RedirectToAction("Index");
        }
        //ContentResult: trả về nội dung văn bản, hàm sử dụng là Content()
        public ContentResult GetContent()
        {
            return Content("Trường Đại Học Đại Nam");
        }
        //JsonResult: trả về dữ liệu JSON, hàm sử dụng là Json()
        List <string> flowers = new List<string> ()
        { 
            "Man", "Mo", "Đao"
        };
        public JsonResult GetJson()
        {
            return Json(flowers);
        }

        //ViewResult: trả về View, hàm sử dụng là View()
        public ViewResult GetView()
        {
            return View("GetData");
        }
    }
}
