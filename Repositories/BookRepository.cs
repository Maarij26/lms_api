using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Repositories
{

    //Inherits GenericRepository to get all CRUD methods for free
    //Implements IBookRepository to get the books-specific methods.
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        //Fetch book and its author in one SQL query using Include (Join).
        public async Task<Book?> GetBookWithAuthorAsync(int id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAvailableBooksAsync()
        {
            return await _context.Books.Where(b => b.IsAvailable).Include(b => b.Author).ToListAsync();
        }
    }
}
