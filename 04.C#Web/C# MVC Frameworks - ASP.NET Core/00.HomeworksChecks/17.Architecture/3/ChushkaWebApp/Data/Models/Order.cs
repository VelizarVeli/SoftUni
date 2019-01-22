namespace EventWebApp.Data.Models
{
    using System;

    public class Order
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public virtual Event Event { get; set; }

        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public DateTime OrderedOn { get; set; }

        public int TicketsCount { get; set; }
    }
}
