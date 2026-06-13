namespace LibraryManagementSystemAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = " ";
        public string? Country { get; set; }

        //Navigation Property - Collection of books author has written
        public List<Book> Books { get; set; } = new ();
    }
}
