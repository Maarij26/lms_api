using FluentValidation;
using LibraryManagementSystemAPI.DTOs;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookservice;
        private readonly IValidator<CreateBookDTo> _createBookValidator;

        public BooksController(IBookService bookService, IValidator<CreateBookDTo> createBookValidator)
        {
            _bookservice = bookService;
            _createBookValidator = createBookValidator;
        }


        //Get api/Books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookservice.GetAllBooksAsync();

            var response = books.Select(b => new BookResponseDTo
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                PublicationYear = b.PublicationYear,
                IsAvailable = b.IsAvailable,
                AuthorId = b.AuthorId,
                AuthorName = b.Author?.Name ?? "Unknown"
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {

            var book = await _bookservice.GetBookByIdAsync(id);

            if (book == null)
                return NotFound($"Book with id {id} not found.");

            // Map to response DTo

            var response = new BookResponseDTo
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,
                IsAvailable = book.IsAvailable,
                AuthorId = book.AuthorId,
                AuthorName = book.Author?.Name ?? "Unknown"
            };
            return Ok(response);
        }

        ////Get api/books/available
        [HttpGet("available")]

        public async Task<IActionResult> GetAvailableBooks()
        {
            var books = await _bookservice.GetAvailableBooksAsync();

            var response = books.Select(b => new BookResponseDTo
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                IsAvailable = b.IsAvailable,
                PublicationYear = b.PublicationYear,
                AuthorId = b.AuthorId,
                AuthorName = b.Author?.Name ?? "Unknown"

            });
            return Ok(response);
        }

        //Post api/books
        //Creates a new book

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] CreateBookDTo dto)
        {
            //Validate using fluent validation
            var validationResult = await _createBookValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));


            //Map DTO to book model

            var book = new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
                PublicationYear = dto.PublicationYear,
                AuthorId = dto.AuthorId,
                IsAvailable = true

            };

            var result = await _bookservice.AddBookAsync(book);

            if (!result)
                return BadRequest("Could not add book. Check published year and ISBN.");

            // 201 Created - standard response for successful POST
            return StatusCode(201, "Book created successfully");
        }

        // PUT api/books/5
        // Updates an existing book
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDTo dto)
        {
            // id in URL must match id in body
            if (id != dto.Id)
                return BadRequest("ID in URL does not match ID in body");

            // Map DTO to Book model
            var book = new Book
            {
                Id = dto.Id,
                Title = dto.Title,
                ISBN = dto.ISBN,
                PublicationYear = dto.PublicationYear,
                IsAvailable = dto.IsAvailable,
                AuthorId = dto.AuthorId
            };

            var result = await _bookservice.UpdateBookAsync(book);

            if (!result)
                return NotFound($"Book with ID {id} not found");

            return Ok("Book updated successfully");
        }

        // DELETE api/books/5
        // Deletes a book by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookservice.DeleteBookAsync(id);

            if (!result)
                return NotFound($"Book with ID {id} not found");

            return Ok("Book deleted successfully");
        }
    }
}