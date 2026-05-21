using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureJwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        //
        // USER ACCESS
        //
        [Authorize]
        [HttpGet("user")]
        public IActionResult UserData()
        {
            return Ok("Authenticated User Access");
        }

        //
        // ADMIN ACCESS
        //
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminData()
        {
            return Ok("Admin Access Granted");
        }
    }
}