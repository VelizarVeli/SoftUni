namespace EventuresWebApp.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateEventViewModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "Name should be at least 10 symbols long.")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name should be at least 3 symbols long.")]
        public string Place { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Total tickets shoud be a positive number.")]
        public int TotalTickets { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price per ticket should be a positive number.")]
        public decimal PricePerTicket { get; set; }
    }
}
