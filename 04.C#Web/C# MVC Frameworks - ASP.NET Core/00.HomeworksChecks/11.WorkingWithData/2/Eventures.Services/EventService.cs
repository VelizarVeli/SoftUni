using Eventures.Services.Contracts;
using Eventures.Data;
using Eventures.Models;
using System;
using System.Collections.Generic;
using Eventures.Models.ViewModels.Event;
using System.Linq;

namespace Eventures.Services
{
    public class EventService : IEventService
    {
        private readonly EventuresDbContext db;
        public EventService(EventuresDbContext db)
        {
            this.db = db;
        }        
        
        public void Create(string name,string place, DateTime startDate, DateTime endDate, int tickets, decimal price)
        {
            var createdEvent = new Event()
            {
                Name = name,
                Place = place,
                Start = startDate,
                End = endDate,
                Tickets = tickets,
                PricePerTicket = price
            };
            db.Events.Add(createdEvent);
            db.SaveChanges();
        }
        public IEnumerable<EventListViewModel> All()
        {
            var events = db.Events.Select(e => new EventListViewModel()
            {
                Name = e.Name,
                Place = e.Place,
                Start = e.Start,
                End = e.End
            })
            .ToList();

            return events;
        }
    }
}
