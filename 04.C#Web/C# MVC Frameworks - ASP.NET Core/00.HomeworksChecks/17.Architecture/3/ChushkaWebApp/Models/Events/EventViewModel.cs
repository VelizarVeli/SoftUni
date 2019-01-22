namespace EventWebApp.Models.Events
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Models;
    using Orders;

    public class EventViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name length must be at least 10 characters", MinimumLength = 10)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Place should not be empty",AllowEmptyStrings=false)]
        public string Place { get; set; }

        [Required(ErrorMessage = "Start date should not be empty")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy H:mm:ss}")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "End date should not be empty")]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        [Required(ErrorMessage = "TotalTickets should not be empty")]
        [Range(0, int.MaxValue, ErrorMessage = "Total tickets must be a positive number")]
        public int TotalTickets { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerTicket { get; set; }

        public OrderViewModel Order { get; set; }

        [DisplayName("Tickets")]
        [Required(ErrorMessage = "Tickets count should not be empty")]
        [Range(0, int.MaxValue, ErrorMessage = "Tickets count must be a positive number")]
        public int TicketsCount { get; set; }

    }
}
