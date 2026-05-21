using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        [Authorize(Policy = "CanEditTaskPolicy")]
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}