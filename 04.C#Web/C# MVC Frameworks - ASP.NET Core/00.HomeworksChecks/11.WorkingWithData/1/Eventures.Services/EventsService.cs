using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;

namespace Eventures.Services
{
    public class EventsService : IEventsService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EventsService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ICollection<T> All<T>()
        {
            return this.context.Events.Select(x => this.mapper.Map<T>(x)).ToList();
        }

        public bool Create(string name, string place, DateTime start, DateTime end, int totalTickets, decimal pricePerTicket)
        {
            if (name == null ||
                place == null ||
                start == null ||
                end == null ||
                totalTickets == null ||
                pricePerTicket == null) return false;

            var appEvent = new Event
            {
                Name = name,
                Place = place,
                Start = start,
                End = end,
                TotalTickets = totalTickets,
                PricePerTicket = pricePerTicket
            };

            context.Events.Add(appEvent);
            context.SaveChanges();

            return true;
        }
    }
}
