using System.Collections.Generic;

namespace ChushkaWebApp.ViewModels.Orders
{
    public class AllOrdersViewModel
    {
        public ICollection<OrderViewModel> All { get; set; }
    }
}
