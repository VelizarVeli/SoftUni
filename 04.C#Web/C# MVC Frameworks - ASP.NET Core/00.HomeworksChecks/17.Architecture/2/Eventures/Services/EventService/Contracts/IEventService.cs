namespace Eventures.Services.EventService.Contracts
{
    using Eventures.Models;
    using System.Linq;

    public interface IEventService
    {
        IQueryable<Event> All();
    }
}
