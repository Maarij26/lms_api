namespace LibraryManagementSystemAPI.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        //Making 1-1 relationships with book and member and also the many-many among books and members through borrow records
        public Book? Book { get; set; }
        public int MemberId { get; set; }
        public Member? Member { get; set; } 
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}

