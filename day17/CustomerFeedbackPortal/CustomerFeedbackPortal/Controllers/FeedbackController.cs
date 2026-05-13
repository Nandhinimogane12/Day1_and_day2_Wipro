using Microsoft.AspNetCore.Mvc;
using CustomerFeedbackPortal.Models;

namespace CustomerFeedbackPortal.Controllers
{
    public class FeedbackController : Controller
    {
        // Static list to store feedback in memory for demo
        private static List<Feedback> _feedbacks = new List<Feedback>();

        public IActionResult Index()
        {
            return View(_feedbacks.OrderByDescending(f => f.SubmittedOn));
        }

        [HttpGet] // This is the missing piece causing 404
        public IActionResult Create()
        {
            return View(new Feedback()); // Sends empty form to Create.cshtml
        }

        [HttpPost] // Handles form submit
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Id = _feedbacks.Count + 1;
                _feedbacks.Add(feedback);
                TempData["Success"] = "Thank you for your feedback!";
                return RedirectToAction("Index");
            }
            return View(feedback); // Return with validation errors
        }
    }
}