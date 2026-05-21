using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
            : base(context)
        {
            _context = context;
        }

        // SEARCH BOOKS

        public async Task<IEnumerable<Book>> SearchBooks(string search)
        {
            return await _context.Books
                .Where(b => b.Title.Contains(search))
                .ToListAsync();
        }

        // PAGINATION

        public async Task<IEnumerable<Book>> GetPagedBooks(int pageNumber, int pageSize)
        {
            return await _context.Books
                .OrderBy(b => b.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}