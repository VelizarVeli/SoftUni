using Eventures.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Services.Contracts
{
    public interface IEventsService
    {
        Task CreateEventAsync<T>(T model);

        IEnumerable<T> GetAllAvailableEvents<T>();

        Event GetById(string id);

        IEnumerable<T> GetMyEvents<T>(string username);
    }
}
