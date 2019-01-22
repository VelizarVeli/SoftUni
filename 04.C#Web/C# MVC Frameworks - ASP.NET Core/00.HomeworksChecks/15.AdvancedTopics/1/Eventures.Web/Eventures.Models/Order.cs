using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventures.Models
{
    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime OrderedOn { get; set; }

        [ForeignKey(nameof(Event))]
        public string EventId { get; set; }
        public virtual Event Event { get; set; }

        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }
        public virtual EventuresUser Customer { get; set; }

        public int TicketsCount { get; set; }
    }
}
