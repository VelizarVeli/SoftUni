using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.Models.ViewModels;
using Eventures.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Eventures.Services
{
    public class EventService : IEventService
    {
        private readonly ILogger<EventService> logger;
        public EventuresDbContext Context { get; }
        public IMapper Mapper { get; }

        public EventService(EventuresDbContext context, 
                            ILogger<EventService> logger,
                            IMapper mapper)
        {
            this.logger = logger;
            Context = context;
            Mapper = mapper;
        }

        public async Task<IEnumerable<EventViewModel>> GetAllEventsAsync()
        {
            var events = await this.Context.Events
                .Where(e => e.TotalTickets > 0)
                .Select(e => this.Mapper.Map<EventViewModel>(e))
                .ToListAsync();

            return events;
        }

        public void CreateEvent(CreateViewModel model)
        {
            var newEvent = new Event()
            {
                Name = model.Name,
                TotalTickets = model.TotalTickets,
                PricePerTicket = model.PricePerTicket,
                End = model.End,
                Start = model.Start,
                Place = model.Place
            };

            this.Context.Events.Add(newEvent);
            this.Context.SaveChanges();

            this.logger.LogInformation($"EventName created: {newEvent.Name}");
        }

        public void Order(int tickets, string userId, Guid eventId)
        {
            this.ReduceEventTickets(tickets, eventId);

            var order = new Order()
            {
                EventId = eventId,
                OrderedOn = DateTime.UtcNow,
                TicketsCount = tickets,
                UserId = userId
            };

            this.Context.Orders.Add(order);
            this.Context.SaveChanges();
        }

        public IEnumerable<MyEventsViewModel> GetMyEvents(ApplicationUser user)
        {
            var events = user.Orders
                .Select(o => this.Mapper.Map<MyEventsViewModel>(o));

            return events;
        }

        public IEnumerable<AllOrdersViewModel> GetAllOrders()
        {
            var orders = this.Context.Orders
                .ToList()
                .Select(o => this.Mapper.Map<AllOrdersViewModel>(o));

            return orders;
        }

        public int GetTicketsLeft(Guid eventId)
        {
            var currentEvent = this.Context.Events
                .FirstOrDefault(e => e.Id == eventId);

            return currentEvent.TotalTickets;
        }

        private void ReduceEventTickets(int tickets, Guid eventId)
        {
            var currentEvent = this.Context.Events
                .FirstOrDefault(e => e.Id == eventId);

            currentEvent.TotalTickets -= tickets;

            this.Context.Events.Update(currentEvent);
            this.Context.SaveChanges();
        }
    }
}
