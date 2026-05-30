using Microsoft.AspNetCore.Mvc;

namespace OnlineFoodDeliveryPortal.Controllers
{
    [Route("restaurant")]
    public class RestaurantController : Controller
    {
        [Route("menu")]
        public IActionResult Menu()
        {
            return Content("Restaurant Menu");
        }

        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            return Content("Restaurant Details: " + id);
        }
    }
}