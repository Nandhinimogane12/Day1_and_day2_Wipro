using Microsoft.AspNetCore.Mvc;

namespace CustomerEngagementPlatform.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketSummaryController : ControllerBase
    {
        [HttpPost]
        public IActionResult Summarize(string description)
        {
            return Ok(new
            {
                Summary = "AI-generated ticket summary would appear here."
            });
        }
    }
}