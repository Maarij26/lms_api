using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book?> GetBookWithAuthorAsync(int id);
        Task<IEnumerable<Book>> GetAvailableBooksAsync();
    }
}
