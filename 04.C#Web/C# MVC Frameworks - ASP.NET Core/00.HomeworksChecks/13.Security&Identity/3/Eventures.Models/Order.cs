using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Eventures.Models
{
    //•	Ordered On – a DateTime object.
    //•	Event – an Event object.
    //•	Customer – a User object.
    //•	Tickets Count – an integer.


    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.OrderedOn = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public string CustomerId { get; set; }
        public virtual EventureUser Customer  { get; set; }

        public int TicketsCount { get; set; }
    }
}
