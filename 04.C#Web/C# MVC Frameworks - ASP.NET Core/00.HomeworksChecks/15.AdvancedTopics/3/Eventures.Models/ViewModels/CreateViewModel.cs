using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventures.Models.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "Name must be at least {1} characters long!")]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Start field is not in valid date format!")]
        [DisplayFormat(DataFormatString = "dd-MMM-yy HH:mm:ss")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "End field is not in valid date format!")]
        public DateTime End { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Value must be a positive number!")]
        public int TotalTickets { get; set; }
        
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal PricePerTicket { get; set; }
    }
}
