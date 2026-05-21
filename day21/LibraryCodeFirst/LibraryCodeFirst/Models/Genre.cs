namespace LibraryCodeFirst.Models
{
    public class Genre
    {
        public int GenreID { get; set; } // Capital ID
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}