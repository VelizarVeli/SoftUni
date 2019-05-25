using System;
using System.ComponentModel.DataAnnotations;
using Panda.Model.Enums;

namespace Panda.Model
{
    public class Package : BaseId
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public string RecipientId { get; set; }
        public virtual PandaUser Recipient { get; set; }
    }
}