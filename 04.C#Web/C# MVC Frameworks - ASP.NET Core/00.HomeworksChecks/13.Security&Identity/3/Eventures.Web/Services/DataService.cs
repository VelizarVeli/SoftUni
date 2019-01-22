using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using Eventures.Web.Data;
using Eventures.Web.ViewModels;

namespace Eventures.Web.Services
{
    public class DataService : IDataService
    {
        // ReSharper disable once InconsistentNaming
        private readonly ApplicationDbContext db;

        public DataService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateEvent(CreateEventViewModel model)
        {
            var ev = new Event()
            {
                Name = model.Name,
                Place = model.Place,
                Start = model.Start,
                End = model.End,
                PricePerTicket = model.PricePerTicket,
                TotalTickets = model.TotalTickets
            };

            this.db.Add(ev);
            this.db.SaveChanges();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return this.db.Events;
        }

        public Event GetLastCreatedEvent()
        {
            return this.db.Events.Last();
        }

        public void OrderTicketsForEvent(int eventId, int ticketsCount, string customer)
        {
            var ev = this.db.Events.FirstOrDefault(x => x.Id == eventId);
            var user = this.db.Users.FirstOrDefault(x => x.UserName == customer);

            var order = new Order()
            {
                Customer = user,
                Event = ev,
                TicketsCount = ticketsCount
            };

            this.db.Add(order);
            this.db.SaveChanges();
        }

        public IEnumerable<Order> GetUserEvents(string name)
        {
            return this.db.Orders.Where(x => x.Customer.UserName == name).ToList();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return this.db.Orders.ToList();
        }
    }
}
