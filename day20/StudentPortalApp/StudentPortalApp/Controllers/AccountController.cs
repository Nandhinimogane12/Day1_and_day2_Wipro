using Microsoft.AspNetCore.Mvc;

namespace StudentPortalApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login submit
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Simple validation - replace with DB check later
            if (!string.IsNullOrEmpty(username) && password == "1234")
            {
                // Store username in Session
                HttpContext.Session.SetString("UserName", username);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        // GET: Dashboard - check session
        public IActionResult Dashboard()
        {
            // Check if user is logged in
            string userName = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login"); // Not logged in
            }

            ViewBag.User = userName;
            return View();
        }

        // GET: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return RedirectToAction("Login");
        }
    }
}
