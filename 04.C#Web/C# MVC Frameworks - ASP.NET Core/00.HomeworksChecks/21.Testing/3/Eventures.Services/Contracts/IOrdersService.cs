using Eventures.Models;
using Eventures.Services.Models.Orders;
using System.Collections;
using System.Collections.Generic;

namespace Eventures.Services.Contracts
{
    public interface IOrdersService
    {
        void CreateOrder(Event eventureEvent, User customer, int ticketCount);

        ICollection<AllOrdersViewModel> All();

        ICollection AllByUser(string username);
    }
}
