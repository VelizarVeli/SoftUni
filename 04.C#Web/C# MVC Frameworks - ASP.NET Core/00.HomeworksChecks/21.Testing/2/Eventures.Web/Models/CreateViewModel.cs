
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models
{
    public class CreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Start { get; set; }

        [Required]
        public string End { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        [Display(Name = "Total Tickets")]
        public int TotalTickets { get; set; }

        [Required]
        [Display(Name = "Price Per Ticket")]
        public decimal PricePerTicket { get; set; }
    }
}
