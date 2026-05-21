using LibraryDbFirst.Data;
using LibraryDbFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.EF;

namespace LibraryDbFirst.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryDbContext _context;

        public BooksController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            ViewData["CurrentFilter"] = searchString;

            int pageSize = 10;
            int pageNumber = page ?? 1;

            IQueryable<Book> books = _context.Books
            .Include(b => b.Author)
            .Include(b => b.GenresGenres)
            .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString)
                                      || b.Author.Name.Contains(searchString));
            }

            books = books.OrderBy(b => b.Title);

            return View(await books.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books
            .Include(b => b.Author)
            .Include(b => b.GenresGenres)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null) return NotFound();

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name");
            ViewData["GenreIds"] = new MultiSelectList(_context.Genres, "GenreId", "Name");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,AuthorId")] Book book, int[] genreIds)
        {
            if (ModelState.IsValid)
            {
                if (genreIds != null && genreIds.Length > 0)
                {
                    book.GenresGenres = await _context.Genres
                    .Where(g => genreIds.Contains(g.GenreId))
                    .ToListAsync();
                }

                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name", book.AuthorId);
            ViewData["GenreIds"] = new MultiSelectList(_context.Genres, "GenreId", "Name", genreIds);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books
            .Include(b => b.GenresGenres)
            .FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null) return NotFound();

            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name", book.AuthorId);
            ViewData["GenreIds"] = new MultiSelectList(_context.Genres, "GenreId", "Name", book.GenresGenres.Select(g => g.GenreId));
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,AuthorId")] Book book, int[] genreIds)
        {
            if (id != book.BookId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var bookToUpdate = await _context.Books
                    .Include(b => b.GenresGenres)
                    .FirstOrDefaultAsync(b => b.BookId == id);

                    if (bookToUpdate == null) return NotFound();

                    bookToUpdate.Title = book.Title;
                    bookToUpdate.AuthorId = book.AuthorId;

                    bookToUpdate.GenresGenres.Clear();

                    if (genreIds != null && genreIds.Length > 0)
                    {
                        var genres = await _context.Genres
                        .Where(g => genreIds.Contains(g.GenreId))
                        .ToListAsync();

                        foreach (var genre in genres)
                        {
                            bookToUpdate.GenresGenres.Add(genre);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name", book.AuthorId);
            ViewData["GenreIds"] = new MultiSelectList(_context.Genres, "GenreId", "Name", genreIds);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books
            .Include(b => b.Author)
            .Include(b => b.GenresGenres)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.BookId == id);

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
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}