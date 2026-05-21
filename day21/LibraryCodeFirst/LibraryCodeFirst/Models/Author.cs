namespace LibraryCodeFirst.Models
{
    public class Author
    {
        public int AuthorID { get; set; } // Capital ID
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}