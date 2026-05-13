using BookStoreApp.Models;
using BookStoreApp.Data;

namespace BookStoreApp.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks() => _bookRepository.GetAllBooks();
        public Book GetBookById(int id) => _bookRepository.GetBookById(id);
        public void AddBook(Book book) => _bookRepository.AddBook(book);
        public void UpdateBook(Book book) => _bookRepository.UpdateBook(book);
        public void DeleteBook(int id) => _bookRepository.DeleteBook(id);
    }
}