using Microsoft.AspNetCore.Mvc;

public class CartController : Controller
{
    // User Story 2: Dynamic routing based on login
    public IActionResult Checkout()
    {
        bool isLoggedIn = User.Identity?.IsAuthenticated ?? false;

        // For demo: check query string?login=true
        if (Request.Query["login"] == "true" || isLoggedIn)
        {
            return View("Checkout");
        }
        else
        {
            return RedirectToAction("Login", "Account");
        }
    }
}