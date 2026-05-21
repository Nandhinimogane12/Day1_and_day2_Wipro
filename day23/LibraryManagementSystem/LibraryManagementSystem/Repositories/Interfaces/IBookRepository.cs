using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> SearchBooks(string search);

        Task<IEnumerable<Book>> GetPagedBooks(int pageNumber, int pageSize);
    }
}