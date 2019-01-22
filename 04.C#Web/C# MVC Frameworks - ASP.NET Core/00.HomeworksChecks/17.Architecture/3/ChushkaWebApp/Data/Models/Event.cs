namespace EventWebApp.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Event
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalTickets { get; set; }

        public decimal PricePerTicket { get; set; }

        public virtual ICollection<Order> UsersOrders { get; set; } = new List<Order>();

    }
}
