namespace Eventures.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Order
    {
        public string Id { get; set; } 

        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;

        public Event Event { get; set; }

        public EventuresUser Customer { get; set; }

        public int TicketCount { get; set; }
    }
}
