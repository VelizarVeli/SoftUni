namespace Eventures.Services.EventService
{
    using Eventures.Data;
    using Eventures.Models;
    using Eventures.Services.EventService.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventService : IEventService
    {
        private readonly ApplicationDbContext context;

        public EventService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Event> All()
        => this.context.Events;
    }
}
