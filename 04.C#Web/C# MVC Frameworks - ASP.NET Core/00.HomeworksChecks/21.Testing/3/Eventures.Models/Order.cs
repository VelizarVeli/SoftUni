using System;

namespace Eventures.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public string EventId { get; set; }
        public Event EventureEvent { get; set; }

        public string CustomerId { get; set; }
        public User Customer { get; set; }

        public int TicketCount { get; set; }
    }
}
