using System;
using Panda.Model.Enums;

namespace Panda.Common.ViewModels.Packages
{
   public class PackageDetailsViewModel
    {
        public string Address { get; set; }
        public Status Status { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public double Weight { get; set; }
        public string Recipient { get; set; }
        public string Description { get; set; }
    }
}