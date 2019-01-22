namespace Eventures.Models
{
    using System;

    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public Event Event { get; set; }

        public EventureUser Customer { get; set; }

        public int TicketsCount { get; set; }
    }
}