using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Clean Code", Author = "Robert Martin", ISBN = "123", Price = 45.99M },
            new Book { Id = 2, Title = "Design Patterns", Author = "Erich Gamma", ISBN = "456", Price = 54.99M }
        };

        // CHANGED: Search added
        public IActionResult Index(string searchString)
        {
            var books = _books;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = _books.Where(b => b.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                       || b.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(books);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken] // ADDED: Security
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid) // ADDED: Validation check
            {
                book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
                _books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var existing = _books.FirstOrDefault(b => b.Id == book.Id);
                if (existing != null)
                {
                    existing.Title = book.Title;
                    existing.Author = book.Author;
                    existing.ISBN = book.ISBN;
                    existing.Price = book.Price;
                }
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null) _books.Remove(book);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return View(book);
        }
    }
}