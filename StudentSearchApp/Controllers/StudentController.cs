using Microsoft.AspNetCore.Mvc;
using StudentSearchApp.Models; // Project name ah maathunga
using System.Linq;

namespace StudentSearchApp.Controllers // Project name ah maathunga
{
    public class StudentController : Controller
    {
        // Dummy data - test ku use pannunga. Real la DB use pannalaam
        private static List<Student> students = new List<Student>
        {
            new Student { StudentId = 101, Name = "Anch", Course = "B.Tech CSE", Email = "anch@mail.com", Age = 20 },
            new Student { StudentId = 102, Name = "Pia", Course = "B.Sc IT", Email = "pia@mail.com", Age = 20 },
            new Student { StudentId = 103, Name = "Dhoni", Course = "MBA", Email = "dhoni@mail.com", Age = 44 }
        };

        // 1. View kaata
        public IActionResult Index()
        {
            return View();
        }

        // 2. AJAX ku JSON data return panna
        [HttpGet]
        public JsonResult GetStudent(int studentId)
        {
            var student = students.FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                // Student illa na error message
                return Json(new { success = false, message = "Student not found" });
            }

            // Student irundha data return pannu
            return Json(new { success = true, data = student });
        }
    }
}