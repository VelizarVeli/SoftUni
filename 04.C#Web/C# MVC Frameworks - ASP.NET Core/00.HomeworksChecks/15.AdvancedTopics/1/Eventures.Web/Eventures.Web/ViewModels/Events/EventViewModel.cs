using Eventures.Web.ViewModels.Orders;

namespace Eventures.Web.ViewModels.Events
{
    public class EventViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public int TotalTickets { get; set; }
        
        public CreateOrderBindingModel Order { get; set; }
    }
}
