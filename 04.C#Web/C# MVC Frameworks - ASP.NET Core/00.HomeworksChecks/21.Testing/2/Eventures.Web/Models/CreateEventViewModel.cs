
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models
{
    public class CreateEventViewModel
    {
        [Required(ErrorMessage = "Name of the event should be at least 10 characters!")]
        [MinLength(10)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Start date is required!")]
        [DataType(DataType.DateTime)]
        public string Start { get; set; }

        [Required(ErrorMessage = "End date is required!")]
        [DataType(DataType.DateTime)]
        public string End { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Place is required!")]
        public string Place { get; set; }

        [Required(ErrorMessage = "Total Tickets is required!")]
        [Display(Name = "Total Tickets")]
        [Range(1, int.MaxValue, ErrorMessage = "Total tickets cannot be zero or negative!")]
        public int TotalTickets { get; set; }

        [Required(ErrorMessage = "Price per Tickets is required!")]
        [Display(Name = "Price Per Ticket")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "Price per Ticket cannot be zero or negative!")]
        public decimal PricePerTicket { get; set; }
    }
}
