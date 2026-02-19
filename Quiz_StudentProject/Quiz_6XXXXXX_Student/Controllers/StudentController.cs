using Microsoft.AspNetCore.Mvc;

namespace Quiz_6XXXXXX_Student.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/Index
        public IActionResult Index(string userId)
        {
            ViewBag.UserId = userId ?? TempData["UserId"]?.ToString() ?? "Guest";
            return View();
        }

        // GET: Student/MyDetails
        public IActionResult MyDetails()
        {
            ViewBag.StudentId   = "660637090";
            ViewBag.FirstName   = "สมชาย";
            ViewBag.LastName    = "ใจดี";
            ViewBag.Email       = "somchai@student.university.ac.th";
            ViewBag.Faculty     = "วิทยาศาสตร์และเทคโนโลยี";
            ViewBag.Major       = "วิทยาการคอมพิวเตอร์";
            ViewBag.Year        = 3;
            ViewBag.PhoneNumber = "081-111-1111";
            ViewBag.GPA         = 3.50;
            ViewBag.Address     = "123 ถ.พระราม 9 กรุงเทพฯ 10400";
            ViewBag.UserId      = "660637090";
            return View();
        }
    }
}
