using EVENTURES.App.ViewModels;
using EVENTURES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Services.Contracts
{
    public interface IOrderServices
    {
        void AddOrder(Guid id, int tickets, EvUser user);

        ICollection<OrderViewModel> FindMyEvents(string userId);

        ICollection<OrderViewModel> AllOrders();
    }
}
