using System.Collections.Generic;

namespace Panda.Common.ViewModels.Packages
{
   public class PendingShipmentsViewModel
    {
        public IEnumerable<PendingShipmentViewModel> PendingShipments { get; set; }
    }
}