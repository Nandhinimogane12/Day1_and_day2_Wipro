using Microsoft.AspNetCore.Mvc;

namespace OnlineExamPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor Injection
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home Page Accessed");

            return View();
        }
    }
}