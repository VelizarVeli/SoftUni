using System;

namespace Eventures.Models
{
    public class Order
    {
        public string Id { get; set; }

        public Event Event { get; set; }

        public string EventId { get; set; }

        public EventureUser Customer { get; set; }

        public string CustomerId { get; set; }

        public int TicketsCount { get; set; }
        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;
    }
}