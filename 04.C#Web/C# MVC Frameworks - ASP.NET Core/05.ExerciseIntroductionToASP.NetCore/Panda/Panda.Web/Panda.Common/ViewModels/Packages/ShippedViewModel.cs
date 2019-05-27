using System;

namespace Panda.Common.ViewModels.Packages
{
    public class ShippedViewModel
    {
        public string Description { get; set; }

        public double Weight { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public string Recipient { get; set; }

        public Guid PackageId { get; set; }
    }
}
