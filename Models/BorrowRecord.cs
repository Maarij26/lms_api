namespace LibraryManagementSystemAPI.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
