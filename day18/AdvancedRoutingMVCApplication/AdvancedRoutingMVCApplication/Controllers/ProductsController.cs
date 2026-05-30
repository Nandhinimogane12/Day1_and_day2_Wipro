using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    // User Story 1: Complex route /Products/{category}/{id}
    public IActionResult Details(string category, int id)
    {
        ViewBag.Category = category;
        ViewBag.Id = id;
        ViewBag.Message = $"Showing product {id} from category {category}";
        return View();
    }
}