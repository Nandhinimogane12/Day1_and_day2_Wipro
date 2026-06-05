using Microsoft.AspNetCore.Mvc;
using CustomerEngagementPlatform.Interfaces;
using CustomerEngagementPlatform.Models;

namespace CustomerEngagementPlatform.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // Display all customers
        public IActionResult Index()
        {
            try
            {
                var customers = _repository.GetAll();
                return View(customers);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(customer);
                    _repository.Save();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage =
                    "Error while saving customer: " + ex.Message;
            }

            return View(customer);
        }

        // Details
        public IActionResult Details(int id)
        {
            try
            {
                var customer = _repository.GetById(id);

                if (customer == null)
                    return NotFound();

                return View(customer);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // Edit GET
        public IActionResult Edit(int id)
        {
            try
            {
                var customer = _repository.GetById(id);

                if (customer == null)
                    return NotFound();

                return View(customer);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(customer);
                    _repository.Save();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage =
                    "Error while updating customer: " + ex.Message;
            }

            return View(customer);
        }

        // Delete GET
        public IActionResult Delete(int id)
        {
            try
            {
                var customer = _repository.GetById(id);

                if (customer == null)
                    return NotFound();

                return View(customer);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _repository.Delete(id);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage =
                    "Error while deleting customer: " + ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }
    }
}