using Microsoft.AspNetCore.Mvc;

public class BooksController : Controller
{
    private readonly BookRepository _repo;
    public BooksController(BookRepository repo) => _repo = repo;

    public IActionResult Index() // User Story 1 + 5
    {
        var books = _repo.GetAllBooksReader(); // SqlDataReader
        return View(books);
    }

    public IActionResult Create() => View();

    [HttpPost] // User Story 2: Input validate pannum
    public IActionResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            _repo.AddBookSP(book); // User Story 3: Stored Procedure
            return RedirectToAction("Index");
        }
        return View(book);
    }

    public IActionResult DatasetDemo() // User Story 4
    {
        var ds = _repo.GetBooksDataSet(); // DataSet + DataTable
        return View(ds.Tables["Books"]);
    }
}