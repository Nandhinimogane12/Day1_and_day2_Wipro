using Microsoft.AspNetCore.Mvc;

public class UsersController : Controller
{
    // User Story 1: Complex route /Users/{username}/Orders
    public IActionResult Orders(string username)
    {
        ViewBag.Username = username;
        // Fetch orders for username from DB in real app
        return View();
    }
}