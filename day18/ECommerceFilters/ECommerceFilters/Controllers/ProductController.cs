using Microsoft.AspNetCore.Mvc;
using ECommerceFilters.Filters;

namespace ECommerceFilters.Controllers
{
    // User Story 1: Apply auth filter to specific controller
    [ServiceFilter(typeof(CustomAuthenticationFilter))]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            if (id == 0) throw new Exception("Test exception for GlobalExceptionFilter");
            return View();
        }
    }
}