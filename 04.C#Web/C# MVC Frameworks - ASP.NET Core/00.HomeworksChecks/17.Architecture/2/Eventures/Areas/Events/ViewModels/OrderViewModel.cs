using Eventures.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Areas.Events.ViewModels
{
    public class OrderViewModel
    {
        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;

        public Eventures.Models.Event Event { get; set; }

        public EventuresUser Customer { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Number of tickets should be positive number!")]
        public int TicketCount { get; set; }
    }
}
