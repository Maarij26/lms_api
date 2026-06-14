using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.DTOs
{

    //It will be used, when client creating a book (POST Request)
    public class CreateBookDTo
    {
        [Required(ErrorMessage = "Title is Required")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 200 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "ISBN must be between 10 and 13 characters")]
        public string ISBN { get; set; } = string.Empty;

        [Range(1900, 2026, ErrorMessage = "Published Year must be between 1900 and current year")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "AuthorId is required")]
        public int AuthorId { get; set; }
    }

    //This DTO will be used when client updating a book (PUT Request)
    public class  UpdateBookDTo
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; } = string.Empty;
        [Range(1900, 2026)]
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
    //This DTO will be used when client fetching book details (GET Request)
    public class BookResponseDTo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}
