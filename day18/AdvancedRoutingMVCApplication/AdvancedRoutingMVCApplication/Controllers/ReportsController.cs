using Microsoft.AspNetCore.Mvc;

public class ReportsController : Controller
{
    // User Story 3: Custom constraint route /Reports/{reportId:guidcheck}
    public IActionResult View(Guid reportId)
    {
        ViewBag.ReportId = reportId;
        return View();
    }
}