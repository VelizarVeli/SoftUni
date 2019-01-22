using System.ComponentModel.DataAnnotations;

namespace Eventures.Models
{
    using System;

    public class Event
    {
        public string  Id { get; set; }

        [Required]
        [MinLength(10)]
        public string  Name { get; set; }

        [Required]

        public string  Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalTickets { get; set; }

        public decimal PricePerTicket { get; set; }
    }
}
