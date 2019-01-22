using EVENTURES.App.Services.Contracts;
using EVENTURES.App.ViewModels;
using EVENTURES.Data;
using EVENTURES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Services
{
    public class EventServices : IEventServices
    {
        private readonly EventureDbContext context;

        public EventServices(EventureDbContext context)
        {
            this.context = context;
        }

        public void AddEvent(CreateEventViewModel model)
        {
            var eventt = new Event
            {
                Id = model.Id,
                Name = model.Name,
                Place = model.Place,
                Start = model.Start,
                End = model.End,
                PricePerTicket = model.PricePerTicket                
            };

            this.context.Events.Add(eventt);
            this.context.SaveChanges();
        }

        public ICollection<Event> GetAllEvents()
        {
            return this.context.Events.ToList();
        }
    }
}
