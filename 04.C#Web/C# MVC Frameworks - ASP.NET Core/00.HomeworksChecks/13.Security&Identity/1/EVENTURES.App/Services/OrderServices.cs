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
    public class OrderServices : IOrderServices
    {
        private readonly EventureDbContext context;

        public OrderServices(EventureDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(Guid id, int tickets, EvUser user)
        {
            var eventt = this.context.Events.FirstOrDefault(x => x.Id == id);
            
            var order = new Order
            {
                OrderedOn = DateTime.Now,
                EventId = id,
                Event = eventt,
                CustomerId = user.Id,
                Customer = user,
                TicketsCount = tickets
            };

            this.context.Orders.Add(order);

            this.context.SaveChanges();
        }

        public ICollection<OrderViewModel> AllOrders()
        {
            var orders = this.context.Orders.ToList();

            var ordersModels = new List<OrderViewModel>();

            foreach (var item in orders)
            {
                var eventt = this.context.Events.FirstOrDefault(x => x.Id == item.EventId);
                var customer = this.context.Users.FirstOrDefault(x => x.Id == item.CustomerId);

                var or = new OrderViewModel
                {
                    Event = eventt,
                    EventId = item.EventId,
                    Customer = customer,
                    CustomerId = item.CustomerId,
                    OrderedOn = item.OrderedOn
                };

                ordersModels.Add(or);
            }

            return ordersModels;
        }

        public ICollection<OrderViewModel> FindMyEvents(string userId)
        {
            var orders = this.context.Orders.Where(x => x.CustomerId == userId).ToList();
            var orderss = new List<OrderViewModel>();

            foreach (var item in orders)
            {
                var ev = this.context.Events.FirstOrDefault(x => x.Id == item.EventId);
                var order = new OrderViewModel
                {
                    EventId = item.EventId,
                    Event = ev,
                    TicketsCount = item.TicketsCount
                };
                orderss.Add(order);
            }

            return orderss;
        }
    }
}
