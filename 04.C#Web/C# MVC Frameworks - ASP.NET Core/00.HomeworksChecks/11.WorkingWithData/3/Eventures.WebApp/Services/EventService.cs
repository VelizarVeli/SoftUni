namespace Eventures.WebApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using ViewModels;

    public class EventService : IEventService
    {
        public EventService(ApplicationDbContext context)
        {
            this.Context = context;
        }

        private ApplicationDbContext Context { get; }

        public IEnumerable<EventOutputModel> All()
        {
            var events = this.Context.Events.Select(x => new EventOutputModel
            {
                Id = x.Id,
                Name = x.Name,
                Place = x.Place,
                Start = x.Start.ToString("yyyy MMMM dd HH:mm:ss", CultureInfo.InvariantCulture),
                End = x.End.ToString("yyyy MMMM dd HH:mm:ss", CultureInfo.InvariantCulture),
                Tickets = x.TotalTickets
            }).ToList();

            return events;
        }

        public void CreateEvent(EventInputModel model)
        {
            var eventureEvent = new Event
            {
                Name = model.Name,
                PricePerTicket = model.PricePerTicket,
                TotalTickets = model.TotalTickets,
                End = model.End,
                Start = model.End,
                Place = model.Place
            };
            this.Context.Events.Add(eventureEvent);
            this.Context.SaveChanges();
        }

        public IEnumerable<EventOutputModel> UserEvents(string userName)
        {
            var userEvents = this.Context.Orders.Where(x => x.Customer.UserName == userName).Include(x => x.Event).Select(x => new EventOutputModel
            {
                Name = x.Event.Name,
                Place = x.Event.Place,
                Start = x.Event.Start.ToString("yyyy MMMM dd HH:mm:ss", CultureInfo.InvariantCulture),
                End = x.Event.End.ToString("yyyy MMMM dd HH:mm:ss", CultureInfo.InvariantCulture),
                Tickets = x.TicketsCount
            }).ToList();

            return userEvents;
        }

        public IEnumerable<OrderOutputModel> AllOrders()
        {
            var result = this.Context.Orders.Select(x => new OrderOutputModel
            {
                OrderedOn = x.OrderedOn.ToString("yyyy MMMM dd HH:mm:ss", CultureInfo.InvariantCulture),
                CustomerName = x.Customer.UserName,
                EventName = x.Event.Name
            }).ToArray();

            return result;
        }

        public void CreateOrder(Guid id, string username, int tickets)
        {
            var user = this.Context.Users.First(x => x.UserName == username);
            var orderForUser = this.Context.Events.Find(id);

            orderForUser.TotalTickets -= tickets;
            var order = new Order
            {
                Customer = user,
                OrderedOn = DateTime.UtcNow,
                Event = orderForUser,
                TicketsCount = tickets
            };
            this.Context.Orders.Add(order);
            this.Context.SaveChanges();
        }
    }
}