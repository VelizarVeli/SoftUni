using System;

namespace PandaWebApp.Models
{
   public class Package
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public UserStatus Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public int RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}
