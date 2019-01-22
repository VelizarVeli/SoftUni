using Eventures.Services.Contracts;
using Eventures.Data;
using Eventures.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;

namespace Eventures.Services
{
    public class EventsService : IEventsService
    {
        private readonly EventuresDbContext db;

        private UserManager<EventuresUser> userManager;

        private IMapper mapper;

        public EventsService(EventuresDbContext db, UserManager<EventuresUser> userManager, IMapper mapper)
        {
            this.db = db;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task CreateEventAsync<T>(T model)
        {
            Event @event = mapper.Map<Event>(model);

            this.db.Events.Add(@event);

            await this.db.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllAvailableEvents<T>()
        {
            return this.db.Events.Where(e => e.TotalTickets > 0).ProjectTo<T>(this.mapper.ConfigurationProvider).ToList();
        }

        public Event GetById(string id)
        {
            return this.db.Events.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetMyEvents<T>(string username)
        {
            return this.db.Orders.Where(o => o.Customer.UserName == username).ProjectTo<T>(this.mapper.ConfigurationProvider).ToList();
        }
    }
}
