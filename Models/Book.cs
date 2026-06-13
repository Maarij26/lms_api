namespace LibraryManagementSystemAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = " ";
        public string ISBN { get; set; } = " ";
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int AuthorId { get; set; }
        //Navigation Property - Author who wrote the book
        public Author? Author { get; set; }

        //Navigation property - All borrow records associated with the book
        public List<BorrowRecord> BorrowRecords { get; set; } = new();

    }
}
