using System;
using System.Collections.Generic;

namespace Eventures.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalTickets { get; set; }

        public decimal PricePerTicket { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
