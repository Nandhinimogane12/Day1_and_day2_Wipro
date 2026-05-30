using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStoreApp.Models;
using BookStoreApp.Data;

namespace BookStoreApp.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        public CreateModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [BindProperty]
        public Book Book { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _bookRepository.AddBook(Book);
            return RedirectToPage("./Index");
        }
    }
}