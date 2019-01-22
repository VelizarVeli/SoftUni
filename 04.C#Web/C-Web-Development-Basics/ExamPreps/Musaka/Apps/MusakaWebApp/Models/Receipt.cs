using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusakaWebApp.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Orders = new List<Order>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public ICollection<Order> Orders { get; set; }

        public int CashierId { get; set; }
        public User Cashier { get; set; }
    }
}
