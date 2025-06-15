using DatabaseFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFirst.Controllers
{
    public class PhongBanController : Controller
    {
        private readonly QlnhanSuContext _context;
        public PhongBanController()
        {
            _context = new QlnhanSuContext();
        }
        public IActionResult Index()
        {
            var phongBans = _context.PhongBans.ToList();
            return View(phongBans);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PhongBan phongBan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.PhongBans.Add(phongBan);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi thêm phòng ban: " + ex.Message);
            }
            return View(phongBan);
        }
        public IActionResult Delete(string id)
        {
            if (id == null)
                return NotFound();
                PhongBan? phongBan = _context.PhongBans.Find(id);
                if (phongBan != null)
                {
                    _context.PhongBans.Remove(phongBan);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit( string id)
        {
            if (id == null)
                return NotFound();
            PhongBan? phongBan = _context.PhongBans.Find(id);
            if (phongBan != null)
            {    
            return View(phongBan);
            }
            return RedirectToAction("Index");
        }
        //Tự Làm
        [HttpPost]
        public IActionResult Edit(PhongBan phongBan)
        {

            if (ModelState.IsValid)
            {
                _context.PhongBans.Update(phongBan);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongBan);
        }
    }
}
