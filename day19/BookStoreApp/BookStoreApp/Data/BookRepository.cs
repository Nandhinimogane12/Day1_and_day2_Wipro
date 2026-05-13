using BookStoreApp.Models;

namespace BookStoreApp.Data
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "C# Basics", Author = "John", ISBN = "123", Price = 29.99M },
            new Book { Id = 2, Title = "ASP.NET Core", Author = "Jane", ISBN = "456", Price = 39.99M }
        };

        private static int _nextId = 3;

        public List<Book> GetAllBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existing = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.ISBN = book.ISBN;
                existing.Price = book.Price;
            }
        }

        public void DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null) _books.Remove(book);
        }
    }
}