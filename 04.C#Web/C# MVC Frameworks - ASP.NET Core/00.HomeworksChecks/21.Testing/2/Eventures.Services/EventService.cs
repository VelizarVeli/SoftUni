using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace Eventures.Services
{
    public class EventService : IEventService
    {
        private readonly EventuresDbContext dbContext;

        public EventService(EventuresDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Event eventDb)
        {
            this.dbContext.Events.Add(eventDb);
            this.dbContext.SaveChanges();
        }

        public IQueryable<Event> All()
        {
            var query = this.dbContext.Events.Where(e => e.TotalTickets > 0).AsNoTracking().OrderBy(p => p.Name);
            return query;
        }

        public IQueryable<Order> GetMyEvents(string userId)
        {
            var query = this.dbContext.Orders.Include(e => e.Event).Where(e => e.CustomerId == userId).AsNoTracking().OrderBy(p => p.OrderedOn);
            
            return query;
        }
    }
}
