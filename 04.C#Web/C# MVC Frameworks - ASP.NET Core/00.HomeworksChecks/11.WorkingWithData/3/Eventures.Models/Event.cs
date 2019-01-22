namespace Eventures.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(10)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal PricePerTicket { get; set; }

        [Required]
        public string Place { get; set; }
    }
}