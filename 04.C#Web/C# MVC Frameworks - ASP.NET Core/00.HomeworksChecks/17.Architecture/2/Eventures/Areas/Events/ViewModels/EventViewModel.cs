namespace Eventures.Areas.Event.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventViewModel
    {
        public string Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Username must be longer than 10 symbols!")]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [Display(Name ="Total Tickets")]
        public int TotalTickets { get; set; }

        public int TicketCount { get; set; }

        [Required]
        [Display(Name = "Price Per Ticket")]
        public decimal PricePerTicket { get; set; }
    }
}
