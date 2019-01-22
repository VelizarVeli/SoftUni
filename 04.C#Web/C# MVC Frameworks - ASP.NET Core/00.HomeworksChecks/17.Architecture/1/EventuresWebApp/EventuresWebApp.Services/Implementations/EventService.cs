namespace EventuresWebApp.Services.Implementations
{
    using System;
    using EventuresWebApp.Models;
    using System.Linq;
    using Data;
    using System.Collections.Generic;
    using Interfaces;
    using Models;

    public class EventService : IEventService
    {
        private readonly EventuresDbContext db;

        public EventService(EventuresDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<EventModel> All(int page, int pageSize)
        {
            return this.db
                .Events
                .Where(e => e.TicketsLeft > 0)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new EventModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = string.Format("{0:g}", e.Start),
                    End = string.Format("{0:g}", e.End)
                })
                .ToList();
        }

        public void Create(string name, string place, DateTime start, DateTime end, int totalTickets, decimal pricePerTicket)
        {
            Event _event = new Event
            {
                Name = name,
                Place = place,
                Start = start,
                End = end,
                TotalTickets = totalTickets,
                TicketsLeft = totalTickets,
                PricePerTicket = pricePerTicket
            };

            this.db.Events.Add(_event);
            this.db.SaveChanges();
        }

        public EventModel Last()
        {
            return this.db
                .Events
                .Select(e => new EventModel()
                {
                    Name = e.Name,
                    Start = string.Format("{0:g}", e.Start),
                    End = string.Format("{0:g}", e.End)
                })
                .Last();
        }

        public bool Exists(string id)
        {
            return this.db.Events.Any(e => e.Id == id);
        }

        public int Count()
        {
            return this.db.Events.Count(e => e.TicketsLeft > 0);
        }

        public int TicketsLeftById(string id)
        {
            return this.db.Events.First(e => e.Id == id).TicketsLeft;
        }

        public void ReduceTicketsLeftCount(string id, int boughtTicketsCount)
        {
            var _event = this.db.Events.First(e => e.Id == id);
            _event.TicketsLeft -= boughtTicketsCount;
            this.db.SaveChanges();
        }
    }
}
