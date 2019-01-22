using Eventures.Models;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Services.Models.Events
{
    public class CreateOrderViewModel
    {
        [Required]
        public string EventId { get; set; }

        public virtual Event Event { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Tickets")]
        public int TicketsCount { get; set; }
    }
}
