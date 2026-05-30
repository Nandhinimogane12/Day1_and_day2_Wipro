using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        // DISPLAY BOOKS + SEARCH + PAGINATION

        public async Task<IActionResult> Index(string search, int page = 1)
        {
            int pageSize = 5;

            IEnumerable<Book> books;

            if (!string.IsNullOrEmpty(search))
            {
                books = await _repository.SearchBooks(search);
            }
            else
            {
                books = await _repository.GetPagedBooks(page, pageSize);
            }

            ViewBag.CurrentPage = page;

            return View(books);
        }

        // CREATE

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            try
            {
                await _repository.AddAsync(book);

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        // UPDATE

        [HttpPost]
        public async Task<IActionResult> Update(Book book)
        {
            try
            {
                await _repository.UpdateAsync(book);

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        // DELETE

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}