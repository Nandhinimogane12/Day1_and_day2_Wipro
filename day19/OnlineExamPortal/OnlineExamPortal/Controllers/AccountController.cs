using Microsoft.AspNetCore.Mvc;

namespace OnlineExamPortal.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            HttpContext.Session.SetString("User", username);

            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            var user = HttpContext.Session.GetString("User");

            return Content("Welcome " + user);
        }

        public IActionResult SetCookie()
        {
            Response.Cookies.Append("Theme", "Dark");

            return Content("Cookie Created");
        }

        public IActionResult GetCookie()
        {
            var theme = Request.Cookies["Theme"];

            return Content("Theme is " + theme);
        }
    }
}