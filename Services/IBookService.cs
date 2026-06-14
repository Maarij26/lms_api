using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Services
{
    public interface IBookService
    {
        //Get all books

        Task<IEnumerable<Book>> GetAllBooksAsync();

        //Get one book by id with its author

        Task<Book?> GetBookByIdAsync(int id);

        //Get only available books
        Task<IEnumerable<Book>> GetAvailableBooksAsync();

        //Adding new book

        Task<bool> AddBookAsync(Book book);

        //Update existing book
        Task<bool> UpdateBookAsync(Book book);

        //Delete a book by id 

        Task<bool> DeleteBookAsync(int id);
    }
}
