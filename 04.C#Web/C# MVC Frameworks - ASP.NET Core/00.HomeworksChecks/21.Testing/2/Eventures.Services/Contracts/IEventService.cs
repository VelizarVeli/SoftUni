using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using ReflectionIT.Mvc.Paging;

namespace Eventures.Services.Contracts
{
    public interface IEventService
    {
        void Create(Event eventDb);

        IQueryable<Event> All();

        IQueryable<Order> GetMyEvents(string userId);
    }
}
