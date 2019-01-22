namespace EventuresWebApp.Services.Implementations
{
    using Data;
    using EventuresWebApp.Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class OrderService : IOrderService
    {
        private readonly EventuresDbContext db;

        public OrderService(EventuresDbContext db)
        {
            this.db = db;
        }

        public void Order(string eventId, string userId, int ticketsCount)
        {
            var order = new Order
            {
                CustomerId = userId,
                EventId = eventId,
                OrderedOn = DateTime.Now,
                TicketsCount = ticketsCount
            };

            this.db.Orders.Add(order);
            
            this.db.SaveChanges();
        }

        public IEnumerable<OrderModel> ByUserId(string id)
        {
            return this.db
                .Orders
                .Where(o => o.CustomerId == id)
                .GroupBy(o => new {o.EventId, o.Event.Name, o.Event.Start, o.Event.End})
                .Select(o => new OrderModel()
                {
                    EventName = o.Key.Name,
                    EventStart = string.Format("{0:g}", o.Key.Start),
                    EventEnd = string.Format("{0:g}", o.Key.End),
                    TicketsCount = o.Sum(x => x.TicketsCount)
                })
                .ToList();
        }

        public IEnumerable<AdminOrderModel> All()
        {
            return this.db
                .Orders
                .OrderByDescending(o => o.OrderedOn)
                .Select(o => new AdminOrderModel()
                {
                    EventName = o.Event.Name,
                    Customer = (o.Customer.FirstName.Length == 0) ? $"{o.Customer.FirstName} {o.Customer.LastName}" : o.Customer.UserName,
                    OrderedOn = string.Format("{0:g}", o.OrderedOn)
                })
                .ToList();
        }
    }
}
