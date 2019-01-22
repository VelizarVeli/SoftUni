using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models.ViewModels.Event
{
    public class EventCreateViewModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "Name must be at least {1} characters long!")]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Start field is not in valid date format!")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "End field is not in valid date format!")]
        public DateTime End { get; set; }

        [Range(0,Int32.MaxValue, ErrorMessage = "The count of tickets should be a positive number")]
        public int Tickets { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950334")]
        public decimal PricePerTicket { get; set; }
    }
}
