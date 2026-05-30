using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    // User Story 2: Dynamic routing based on user role
    public IActionResult Dashboard()
    {
        // Simulating user role check. In real app use User.IsInRole()
        bool isAdmin = User.IsInRole("Admin"); // or check from session/claims

        // For demo: check query string?role=admin
        if (Request.Query["role"] == "admin" || isAdmin)
        {
            return RedirectToAction("AdminDashboard");
        }
        else
        {
            return RedirectToAction("UserDashboard");
        }
    }

    public IActionResult AdminDashboard()
    {
        ViewBag.Role = "Admin";
        return View("Dashboard");
    }

    public IActionResult UserDashboard()
    {
        ViewBag.Role = "User";
        return View("Dashboard");
    }
}