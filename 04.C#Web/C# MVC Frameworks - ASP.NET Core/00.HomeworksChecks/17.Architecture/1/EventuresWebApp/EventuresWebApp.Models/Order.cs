namespace EventuresWebApp.Models
{
    using System;

    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime OrderedOn { get; set; }

        public string EventId { get; set; }

        public Event Event { get; set; }

        public string CustomerId { get; set; }

        public EventuresUser Customer { get; set; }

        public int TicketsCount { get; set; }
    }
}
