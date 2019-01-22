using System.Collections;
using System.Collections.Generic;
using Eventures.Models;
using Eventures.Web.ViewModels;

namespace Eventures.Web.Services
{
    public interface IDataService
    {
        void CreateEvent(CreateEventViewModel model);

        IEnumerable<Event> GetAllEvents();

        Event GetLastCreatedEvent();

        void OrderTicketsForEvent(int eventId, int ticketsCount, string customer);

        IEnumerable<Order> GetUserEvents(string identityName);

        IEnumerable<Order> GetAllOrders();
    }
}