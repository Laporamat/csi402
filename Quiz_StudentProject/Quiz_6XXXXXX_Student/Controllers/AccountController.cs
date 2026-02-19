using Microsoft.AspNetCore.Mvc;
using Quiz_6XXXXXX_Student.Models.ViewModels;

namespace Quiz_6XXXXXX_Student.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // Store UserId in TempData/Session and redirect to Student/Index
            TempData["UserId"] = model.UserId;
            return RedirectToAction("Index", "Student", new { userId = model.UserId });
        }

        // GET: Account/StudentList
        public IActionResult StudentList()
        {
            var students = new List<StudentViewModel>
            {
                new StudentViewModel { StudentId = "6401001", FirstName = "สมชาย",   LastName = "ใจดี",    Email = "somchai@email.com",   Faculty = "วิทยาศาสตร์",    Major = "คอมพิวเตอร์",    Year = 3, PhoneNumber = "081-111-1111", GPA = 3.50 },
                new StudentViewModel { StudentId = "6401002", FirstName = "สมหญิง",  LastName = "รักเรียน",Email = "somying@email.com",   Faculty = "วิทยาศาสตร์",    Major = "คอมพิวเตอร์",    Year = 3, PhoneNumber = "081-222-2222", GPA = 3.75 },
                new StudentViewModel { StudentId = "6401003", FirstName = "วิชัย",   LastName = "มีสุข",   Email = "wichai@email.com",    Faculty = "วิศวกรรมศาสตร์", Major = "ไฟฟ้า",          Year = 2, PhoneNumber = "081-333-3333", GPA = 2.80 },
                new StudentViewModel { StudentId = "6401004", FirstName = "นภา",    LastName = "สดใส",   Email = "napa@email.com",     Faculty = "บริหารธุรกิจ",   Major = "การตลาด",        Year = 4, PhoneNumber = "081-444-4444", GPA = 3.20 },
                new StudentViewModel { StudentId = "6401005", FirstName = "ธนกร",   LastName = "เจริญ",   Email = "tanakorn@email.com",  Faculty = "วิทยาศาสตร์",    Major = "คณิตศาสตร์",     Year = 1, PhoneNumber = "081-555-5555", GPA = 3.90 },
                new StudentViewModel { StudentId = "6401006", FirstName = "พิมพ์ใจ", LastName = "งามดี",   Email = "pimjai@email.com",    Faculty = "มนุษยศาสตร์",    Major = "ภาษาอังกฤษ",     Year = 2, PhoneNumber = "081-666-6666", GPA = 3.10 },
                new StudentViewModel { StudentId = "6401007", FirstName = "ศักดิ์ชาย",LastName = "ทองดี", Email = "sakchai@email.com",   Faculty = "วิศวกรรมศาสตร์", Major = "โยธา",           Year = 3, PhoneNumber = "081-777-7777", GPA = 2.95 },
                new StudentViewModel { StudentId = "6401008", FirstName = "อรทัย",   LastName = "ดีงาม",   Email = "orathai@email.com",   Faculty = "บริหารธุรกิจ",   Major = "การเงิน",        Year = 4, PhoneNumber = "081-888-8888", GPA = 3.60 },
            };

            return View(students);
        }

        // GET: Account/CalculateForm
        public IActionResult CalculateForm()
        {
            return View(new ScoreViewModel());
        }

        // POST: Account/CalculateForm
        [HttpPost]
        public IActionResult CalculateForm(ScoreViewModel model)
        {
            double total = model.Score1 + model.Score2 + model.Score3 + model.Score4 + model.Score5
                         + model.Score6 + model.Score7 + model.Score8 + model.Score9 + model.Score10;
            double avg = total / 10.0;

            string grade;
            if (avg >= 80) grade = "A";
            else if (avg >= 70) grade = "B";
            else if (avg >= 60) grade = "C";
            else if (avg >= 50) grade = "D";
            else grade = "F";

            ViewBag.Total = total;
            ViewBag.Average = avg.ToString("F2");
            ViewBag.Grade = grade;

            return View(model);
        }
    }
}
