using System.ComponentModel.DataAnnotations;

namespace CustomerEngagementPlatform.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }
}