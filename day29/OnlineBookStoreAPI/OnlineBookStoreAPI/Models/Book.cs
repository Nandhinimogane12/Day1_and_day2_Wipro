using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStoreAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public Author? Author { get; set; }
    }
}