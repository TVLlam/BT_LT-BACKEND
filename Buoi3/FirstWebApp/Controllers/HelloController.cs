using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SayHello()
        {
            return View();
        }
    }
}
