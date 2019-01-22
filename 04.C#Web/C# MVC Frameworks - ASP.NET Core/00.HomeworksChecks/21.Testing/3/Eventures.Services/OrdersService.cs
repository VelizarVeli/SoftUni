using AutoMapper;
using Eventures.Data;
using Eventures.Mapping;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Services.Models.Orders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Eventures.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly EventuresDbContext _dbContext;

        public OrdersService(EventuresDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void CreateOrder(Event eventureEvent, User user, int ticketCount)
        {
            var model = new Order
            {
                Customer = user,
                EventureEvent = eventureEvent,
                TicketCount = ticketCount,
                OrderedOn = DateTime.UtcNow
            };

            eventureEvent.TotalTickets -= ticketCount;

            this._dbContext.Orders.Add(model);
            _dbContext.SaveChanges();
        }

        public ICollection<AllOrdersViewModel> All()
        {
            var orders = this._dbContext.Orders
                .To<AllOrdersViewModel>()
                .ToList();

            return orders;
        }

        public ICollection AllByUser(string username)
        {
            var orders = this._dbContext.Orders
                .Where(o => o.Customer.UserName == username)
                .ToList();

            return orders;
        }

    }
}
