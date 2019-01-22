using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.ViewModels.Events
{
    public class EventCreateViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Place should not be empty.")]
        [DataType(DataType.Text)]
        [Display(Name = "Place")]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End")]
        public DateTime End { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Should be a non-zero integer number.")]
        [DataType(DataType.Text)]
        [Display(Name = "Total Tickets")]
        public int TotalTickets { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price Per Ticket")]
        public decimal TicketPrice { get; set; }
    }
}
