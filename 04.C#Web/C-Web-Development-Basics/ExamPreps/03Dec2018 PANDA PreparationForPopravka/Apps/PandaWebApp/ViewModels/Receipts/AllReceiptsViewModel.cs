using System.Collections.Generic;

namespace PandaWebApp.ViewModels.Receipts
{
    public class AllReceiptsViewModel
    {
        public IEnumerable<ReceiptViewModel> Receipts { get; set; }
    }
}
