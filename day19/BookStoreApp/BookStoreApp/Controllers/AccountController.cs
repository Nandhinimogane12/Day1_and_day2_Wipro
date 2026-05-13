using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                return RedirectToAction("Index", "Books");
            }
            ViewBag.Error = "Invalid login";
            return View();
        }
    }
}