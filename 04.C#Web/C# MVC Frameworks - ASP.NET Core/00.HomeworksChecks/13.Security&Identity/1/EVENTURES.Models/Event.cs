using System;
using System.Collections.Generic;
using System.Text;

namespace EVENTURES.Models
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalTickets { get; set; }

        public decimal PricePerTicket { get; set; }
    }
}
