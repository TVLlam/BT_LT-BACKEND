using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TranVanLam.Models;
using TranVanLam.Models;

namespace BaiVietProject.Controllers
{
    public class BaiVietController : Controller
    {
        private static List<BaiViet> danhSach = new List<BaiViet>
        {
            new BaiViet { MaBaiViet = 1, TieuDe = "Bài viết 1", NoiDung = "Nội dung 1", NgayPost = new DateTime(2025, 5, 10) },
            new BaiViet { MaBaiViet = 2, TieuDe = "Bài viết 2", NoiDung = "Nội dung 2", NgayPost = new DateTime(2025, 5, 11) }
        };

        public IActionResult DanhSach()
        {
            return View(danhSach);
        }

        [HttpGet]
        public IActionResult ThemBaiViet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemBaiViet(BaiViet bv)
        {
            bv.MaBaiViet = danhSach.Count + 1;
            danhSach.Add(bv);
            return RedirectToAction("DanhSach");
        }
    }
}
