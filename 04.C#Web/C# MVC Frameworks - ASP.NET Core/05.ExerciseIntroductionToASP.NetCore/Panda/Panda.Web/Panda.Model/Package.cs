using System;
using Panda.Model.Enums;

namespace Panda.Model
{
    public class Package : BaseId
    {
        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public Guid UserId { get; set; }
        public User Recipient { get; set; }
    }
}