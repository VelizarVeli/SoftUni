using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public Guid EventId { get; set; }

        public virtual Event Event { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int TicketsCount { get; set; }
    }
}
