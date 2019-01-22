using Eventures.Models;
using Eventures.Services.Models.Events;
using Eventures.Web.Models.Events;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Eventures.Services.Contracts
{
    public interface IEventsService
    {
        IEnumerable<Event> AllByStart();

        Task CreateAsync(string name, DateTime start, DateTime end, string place, int totalTickets, decimal pricePerTicket);

        Event GetById(string id);

        ICollection<EventWithTicketsCountViewModel> MyEvents(IIdentity identity);

        bool EventIsValid(Event @event, int ticketsCount);
    }
}
