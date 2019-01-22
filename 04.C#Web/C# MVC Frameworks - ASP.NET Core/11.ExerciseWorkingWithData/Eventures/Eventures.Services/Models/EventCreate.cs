using System.ComponentModel.DataAnnotations;
using Eventures.Models.CustomAttributes;

namespace Eventures.Services.Models
{
    using System;

    public class EventCreate
    {
        [Required]
        [MinLength(10, ErrorMessage = "The name should be at least 10 symbols long")]
        public string  Name { get; set; }

        [Required]
        public string Place { get; set; }

        public DateTime DateNow { get; set; } = DateTime.UtcNow;

        [Required]
        [DateGreaterThan("DateNow")]
        public DateTime Start { get; set; }

        [Required]
        [DateGreater("Start")]
        public DateTime End { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal PricePerTicket { get; set; }
    }
}
