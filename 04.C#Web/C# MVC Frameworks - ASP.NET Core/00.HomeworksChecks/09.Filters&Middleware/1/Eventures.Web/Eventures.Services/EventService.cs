namespace Eventures.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Eventures.Web.Data;
    using Models;
    using Contracts;

    public class EventService : IEventService
    {
        private readonly EventuresDbContext dbContext;
        private readonly IMapper mapper;

        public EventService(EventuresDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public ICollection<T> All<T>()
        {
            var events = this.dbContext.Events.Select(e => this.mapper.Map<T>(e)).ToList();
            return events;
        }

        public bool Create(string name, string place, DateTime start, DateTime end, int totalTickets, decimal ticketPrice)
        {
            var @event = new Event
            {
                Name = name,
                Place = place,
                Start = start,
                End = end,
                TotalTickets = totalTickets,
                TicketPrice = ticketPrice,
            };

            try
            {
                this.dbContext.Events.Add(@event);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
