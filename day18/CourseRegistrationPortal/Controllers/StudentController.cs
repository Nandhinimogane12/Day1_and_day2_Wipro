using Microsoft.AspNetCore.Mvc;
using CourseRegistrationPortal.Models;

namespace CourseRegistrationPortal.Controllers
{
    public class StudentController : Controller
    {
        // GET: /Student/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Student/Register
        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                // Ipo DB illa, so direct ah Success page ku anupuvom
                return View("Success", student);
            }
            // Validation fail aana thirumba form ku pogum
            return View(student);
        }
    }
}