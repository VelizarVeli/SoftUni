using EVENTURES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.ViewModels
{
    public class OrderViewModel
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public string CustomerId { get; set; }
        public EvUser Customer { get; set; }

        public int TicketsCount { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
