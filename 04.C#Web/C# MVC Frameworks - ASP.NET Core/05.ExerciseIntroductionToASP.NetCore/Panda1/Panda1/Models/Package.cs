using System;
using Panda1.Models.Enums;

namespace Panda1.Models
{
    public class Package
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public int RecipientId { get; set; }
        public User Recipient { get; set; }

        public Receipt Receipt { get; set; }
    }
}
