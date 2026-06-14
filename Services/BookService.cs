using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repositories;

namespace LibraryManagementSystemAPI.Services
{
    public class BookService : IBookService
    {

        //The service will be depending on the repository to get data from
        //the database, so we inject it through the constructor.
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //Get all books - no business logic needed, 
        //just call the repository method

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        //Get one book by id with its author - no business logic needed,
        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookWithAuthorAsync(id);
        }
        //Get only available books - no business logic needed,

        public async Task<IEnumerable<Book>> GetAvailableBooksAsync()
        {
            return await _bookRepository.GetAvailableBooksAsync();
        }

        //Business logic - validate before adding book
        public async Task<bool> AddBookAsync(Book book)
        {
            //Published year cannot be in the future
            if (book.PublicationYear > DateTime.UtcNow.Year)
                return false; // Invalid publication year

            //ISBN must not be empty

            if (string.IsNullOrWhiteSpace(book.ISBN))
            
                return false; // Invalid ISBN
            

            await _bookRepository.AddAsync(book);
            return await _bookRepository.SaveChangesAsync();
        }
        //Business logic - Validate before updating book
        public async Task<bool> UpdateBookAsync(Book book)
        {
        //Check if book exists in database or not (before updating)
        
            var existingBook = await _bookRepository.GetByIdAsync(book.Id);
            if (existingBook == null)
                return false;

            _bookRepository.Update(book);
            return await _bookRepository.SaveChangesAsync();
        }
        //Business logic to check either book exists before deleting

        public async Task<bool> DeleteBookAsync(int id)
        {
            //Find the book first
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                return false; //Book doesnot exist

            _bookRepository.Delete(book);
            return await _bookRepository.SaveChangesAsync();    
        }
    }
}
