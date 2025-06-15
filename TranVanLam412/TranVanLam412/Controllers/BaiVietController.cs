using Microsoft.AspNetCore.Mvc;
using TranVanLam412.Models;

namespace TranVanLam412.Controllers
{
    public class BaiVietController : Controller
    {
        static List<BaiViet> baiViets = new List<BaiViet>()
        {
            new BaiViet() {MaBaiViet = 01, TieuDe = "HocDelegate", NoiDung="1", NgayPost="20/2"},
            new BaiViet() {MaBaiViet = 02, TieuDe = "HocCollection", NoiDung="2", NgayPost="23/1"},
            new BaiViet() {MaBaiViet = 03, TieuDe = "Hocinterface", NoiDung="3", NgayPost="23/1"},
        };
        public IActionResult ThemBaiViet()
        {

            return View();
        }

        public IActionResult DanhSach()
        {
            return View();
        }
    }
}