using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    // User Story 1: /Products/{category}/{id}
    public IActionResult Details(string category, int id)
    {
        ViewBag.Category = category;
        ViewBag.Id = id;
        return View();
    }

    // User Story 3: /Products/Filter/{category}/{priceRange}
    public IActionResult Filter(string category, string priceRange)
    {
        ViewBag.Category = category;
        ViewBag.PriceRange = priceRange;
        return View();
    }
}
