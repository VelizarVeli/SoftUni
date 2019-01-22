using System;
using System.Collections.Generic;
using System.Text;

namespace EVENTURES.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public string CustomerId { get; set; }
        public EvUser Customer { get; set; }

        public int TicketsCount { get; set; }
    }
}
