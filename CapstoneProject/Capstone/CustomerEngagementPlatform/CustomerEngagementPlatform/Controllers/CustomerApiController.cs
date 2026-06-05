using Microsoft.AspNetCore.Mvc;

namespace CustomerEngagementPlatform.Controllers
{
    public class CustomerApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
