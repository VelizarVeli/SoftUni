using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;

namespace Eventures.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly EventuresDbContext db;

        private IMapper mapper;

        private IEventsService eventsService;

        public OrdersService(EventuresDbContext db, IMapper mapper, IEventsService eventsService)
        {
            this.db = db;
            this.mapper = mapper;
            this.eventsService = eventsService;
        }

        public async Task CreateOrderAsync<T>(T model, string userId)
        {
            var order = this.mapper.Map<Order>(model);

            order.CustomerId = userId;

            this.db.Orders.Add(order);

            var @event = this.eventsService.GetById(order.EventId);

            @event.TotalTickets -= order.TicketsCount;

            await this.db.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllOrders<T>()
        {
            return this.db.Orders.ProjectTo<T>(this.mapper.ConfigurationProvider).ToList();
        }
    }
}
