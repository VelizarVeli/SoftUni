using System;

namespace Panda.Common.ViewModels.Packages
{
   public class DeliveredViewModel
    {
        public string Description { get; set; }

        public double Weight { get; set; }

        public string Address { get; set; }

        public string Recipient { get; set; }

        public Guid PackageId { get; set; }
    }
}
