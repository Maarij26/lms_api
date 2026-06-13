namespace LibraryManagementSystemAPI.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; } = " ";
        public string Email { get; set; } = " ";
        public string PasswordHash { get; set; } = " ";
        public string Role { get; set; } = "Member";

        //Navigation Property - All borrow records associated with the member

        public List<BorrowRecord> BorrowRecords { get; set; } = new();

    }
    }
