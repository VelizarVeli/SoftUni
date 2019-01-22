using System;
using System.Collections.Generic;

namespace Eventures.Models
{
    public class Event
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalTickets { get; set; }

        public decimal TicketPrice { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
