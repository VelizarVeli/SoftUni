using System;
using System.Linq;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Services
{
    public class OrderService : IOrderService
    {
        private readonly EventuresDbContext dbContext;


        public OrderService(EventuresDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Order reportDb)
        {
            this.dbContext.Orders.Add(reportDb);
            this.dbContext.SaveChanges();
        }

        public IQueryable<Order> GetAll()
        {
            return this.dbContext.Orders
                .Include(o => o.Event)
                .Include(o => o.Customer);
        }

        public Event GetEvent(string id)
        {
            var @event = dbContext.Events.Find(id);
            if (@event != null)
            {
                return @event;
            }
            throw  new Exception();
        }
    }
}