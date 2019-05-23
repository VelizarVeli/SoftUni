using System;

namespace Panda.Common.ViewModels.Receipts
{
    public class ReceiptDetailsViewModel
    {
        public Guid ReceiptNumber { get; set; }
        public DateTime IssuedOn { get; set; }
        public string DeliveryAddress { get; set; }
        public double Weight { get; set; }
        public string PackageDescription { get; set; }
        public string Recipient { get; set; }
        public double Total { get; set; }
    }
}
