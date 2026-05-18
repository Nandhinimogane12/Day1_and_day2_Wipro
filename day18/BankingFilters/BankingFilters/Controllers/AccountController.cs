using Microsoft.AspNetCore.Mvc;
using BankingFilters.Filters;

namespace BankingFilters.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            HttpContext.Session.SetString("UserRole", "User"); // Fake login
            return Content("Logged in as User");
        }

        public IActionResult LoginAsAdmin()
        {
            HttpContext.Session.SetString("UserRole", "Admin"); // Fake admin login
            return Content("Logged in as Admin");
        }

        public IActionResult ViewBalance()
        {
            return Content("Balance: $5000");
        }

        [TypeFilter(typeof(RoleAuthorizationFilter), Arguments = new object[] { "Admin" })]
        public IActionResult DeleteAccount()
        {
            return Content("Account deleted by Admin");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Content("Logged out");
        }
    }
}