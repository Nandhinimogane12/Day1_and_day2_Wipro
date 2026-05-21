using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryCodeFirst.Data;
using LibraryCodeFirst.Models;
using X.PagedList;
using X.PagedList.Extensions;

namespace LibraryCodeFirst.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public IActionResult Index(string searchString, int? page)
        {
            ViewData["CurrentFilter"] = searchString;

            var books = _context.Books
                     .Include(b => b.Author)
                     .Include(b => b.Genres)
                     .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString)
                               || b.Author.Name.Contains(searchString));
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(books.OrderBy(b => b.Title).ToPagedList(pageNumber, pageSize));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books
             .Include(b => b.Author)
             .Include(b => b.Genres)
             .FirstOrDefaultAsync(m => m.BookID == id);

            if (book == null) return NotFound();
            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Name");
            ViewData["Genres"] = _context.Genres.ToList();
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,AuthorID")] Book book, int[] selectedGenres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();

                if (selectedGenres != null && selectedGenres.Length > 0)
                {
                    var newBook = await _context.Books.FindAsync(book.BookID);
                    foreach (var genreId in selectedGenres)
                    {
                        var genre = await _context.Genres.FindAsync(genreId);
                        if (genre != null)
                        {
                            newBook.Genres.Add(genre);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Name", book.AuthorID);
            ViewData["Genres"] = _context.Genres.ToList();
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books
             .Include(b => b.Genres)
             .FirstOrDefaultAsync(b => b.BookID == id);

            if (book == null) return NotFound();

            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Name", book.AuthorID);
            ViewData["Genres"] = _context.Genres.ToList();
            ViewData["SelectedGenres"] = book.Genres.Select(g => g.GenreID).ToList();
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,Title,AuthorID")] Book book, int[] selectedGenres)
        {
            if (id != book.BookID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var bookToUpdate = await _context.Books
                     .Include(b => b.Genres)
                     .FirstOrDefaultAsync(b => b.BookID == id);

                    bookToUpdate.Title = book.Title;
                    bookToUpdate.AuthorID = book.AuthorID;
                    bookToUpdate.Genres.Clear();

                    if (selectedGenres != null)
                    {
                        foreach (var genreId in selectedGenres)
                        {
                            var genre = await _context.Genres.FindAsync(genreId);
                            if (genre != null)
                            {
                                bookToUpdate.Genres.Add(genre);
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Name", book.AuthorID);
            ViewData["Genres"] = _context.Genres.ToList();
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books
             .Include(b => b.Author)
             .Include(b => b.Genres)
             .FirstOrDefaultAsync(m => m.BookID == id);

            if (book == null) return NotFound();
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}