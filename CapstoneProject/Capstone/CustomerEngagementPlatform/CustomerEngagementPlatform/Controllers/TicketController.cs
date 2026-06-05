using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerEngagementPlatform.Data;
using CustomerEngagementPlatform.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerEngagementPlatform.Controllers
{
    public class TicketController : Controller
    {
        private readonly AppDbContext _context;

        public TicketController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ticket
        public IActionResult Index()
        {
            var tickets = _context.Tickets
                                  .Include(t => t.Customer)
                                  .ToList();

            return View(tickets);
        }

        // GET: Ticket/Details/5
        public IActionResult Details(int id)
        {
            var ticket = _context.Tickets
                                 .Include(t => t.Customer)
                                 .FirstOrDefault(t => t.TicketId == id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(
                _context.Customers,
                "CustomerId",
                "Name"
            );

            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Customers = new SelectList(
                _context.Customers,
                "CustomerId",
                "Name",
                ticket.CustomerId
            );

            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public IActionResult Edit(int id)
        {
            var ticket = _context.Tickets.Find(id);

            if (ticket == null)
            {
                return NotFound();
            }

            ViewBag.Customers = new SelectList(
                _context.Customers,
                "CustomerId",
                "Name",
                ticket.CustomerId
            );

            return View(ticket);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Update(ticket);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Customers = new SelectList(
                _context.Customers,
                "CustomerId",
                "Name",
                ticket.CustomerId
            );

            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public IActionResult Delete(int id)
        {
            var ticket = _context.Tickets
                                 .Include(t => t.Customer)
                                 .FirstOrDefault(t => t.TicketId == id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ticket = _context.Tickets.Find(id);

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // AJAX Search
        [HttpGet]
        public IActionResult Search(string keyword)
        {
            var result = _context.Tickets
                                 .Where(t => t.Title.Contains(keyword))
                                 .ToList();

            return Json(result);
        }
    }
}