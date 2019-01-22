using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eventures.Models;
using Eventures.Models.ViewModels;

namespace Eventures.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetAllEventsAsync();

        void CreateEvent(CreateViewModel model);

        void Order(int tickets, string userId, Guid eventId);

        IEnumerable<MyEventsViewModel> GetMyEvents(ApplicationUser user);

        IEnumerable<AllOrdersViewModel> GetAllOrders();

        int GetTicketsLeft(Guid eventId);
    }
}
