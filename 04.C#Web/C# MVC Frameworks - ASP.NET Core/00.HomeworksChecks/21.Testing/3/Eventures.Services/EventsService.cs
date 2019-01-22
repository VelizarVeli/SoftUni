using AutoMapper;
using Eventures.Data;
using Eventures.Mapping;
using Eventures.Models;
using Eventures.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Eventures.Services.Models.Events;
using Eventures.Web.Models.Events;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Eventures.Services
{
    public class EventsService : IEventsService
    {
        private readonly EventuresDbContext _dbContext;

        public EventsService(EventuresDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task CreateAsync(string name, DateTime start, DateTime end, string place, int totalTickets, decimal pricePerTicket)
        {
            var model = new Event
            {
                Name = name,
                Start = start,
                End = end,
                TotalTickets = totalTickets,
                PricePerTicket = pricePerTicket,
                Place = place
            };

            this._dbContext.Eventd.Add(model);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Event> AllByStart()
        {
            var events = this._dbContext.Eventd
                .OrderBy(e => e.Start)
                .ToList();

            return events;
        }

        public ICollection<EventWithTicketsCountViewModel> MyEvents(IIdentity identity)
        {
            var events = this._dbContext
                  .Orders
                  .Where(o => o.Customer.UserName == identity.Name)
                  .To<EventWithTicketsCountViewModel>()
                  .ToList();

            return events;
        }

        public Event GetById(string id)
        {
            var @event = this._dbContext.Eventd.Find(id);

            return @event;
        }

        public bool EventIsValid(Event @event, int ticketsCount)
        {
            return @event.TotalTickets >= ticketsCount;
        }
    }
}
