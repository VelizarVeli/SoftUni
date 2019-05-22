using System;
using System.ComponentModel.DataAnnotations;

namespace Panda.Common.ViewModels.Receipts
{
    public class ReceiptViewModel
    {
        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Fee { get; set; }
        public DateTime IssuedOn { get; set; }
        public string Name { get; set; }
    }
}