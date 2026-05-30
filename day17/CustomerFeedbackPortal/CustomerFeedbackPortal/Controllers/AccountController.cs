using Microsoft.AspNetCore.Mvc;
using CustomerFeedbackPortal.Models;

namespace CustomerFeedbackPortal.Controllers
{
    public class AccountController : Controller
    {
        // Static list for demo. Use DB in real apps
        private static List<UserRegistration> _users = new List<UserRegistration>();

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserRegistration());
        }

        [HttpPost]
        public IActionResult Register(UserRegistration model)
        {
            // User Story 3: Server-side validation
            if (ModelState.IsValid)
            {
                // Check if username exists
                if (_users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("Username", "Username already taken");
                    return View(model);
                }

                _users.Add(model);
                TempData["Username"] = model.Username;
                return RedirectToAction("Success");
            }

            // If invalid, return view with validation errors
            return View(model);
        }

        public IActionResult Success()
        {
            ViewBag.Username = TempData["Username"];
            return View();
        }
    }
}
