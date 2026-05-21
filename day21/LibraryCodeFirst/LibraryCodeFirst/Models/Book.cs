using System.ComponentModel.DataAnnotations;

namespace LibraryCodeFirst.Models
{
    public class Book
    {
        public int BookID { get; set; } // Capital ID

        [Required]
        public string Title { get; set; }

        public int AuthorID { get; set; } // Capital ID - error la ipdi dhan kekudhu
        public Author Author { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>(); // Plural
    }
}