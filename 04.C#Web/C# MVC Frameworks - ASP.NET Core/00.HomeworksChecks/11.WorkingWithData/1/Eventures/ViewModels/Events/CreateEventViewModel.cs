using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.ViewModels.Events
{
    public class CreateEventViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        [MinLength(10)]
        public string Name { get; set; }

        [Required]
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
        [DataType(DataType.Text)]
        [Display(Name = "Total Tickets")]
        [Range(1, int.MaxValue, ErrorMessage = "Should be a non-zero integer number.")]
        public int TotalTickets { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price Per Ticket")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal PricePerTicket { get; set; }
    }
}
