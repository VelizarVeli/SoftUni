using Eventures.Models;

namespace Eventures.Web.Controllers
{
    public class CreateOrderViewModel
    {
        public int TotalTickets { get; set; }
        public string EventId { get; set; }
        public Event Event { get; set; }
        public EventureUser Customer { get; set; }
        public string CustomerId { get; set; }
    }
}