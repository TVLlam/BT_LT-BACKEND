using Dependencylnjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dependencylnjection.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService = new StudentService();
        public IActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }
    }
}
