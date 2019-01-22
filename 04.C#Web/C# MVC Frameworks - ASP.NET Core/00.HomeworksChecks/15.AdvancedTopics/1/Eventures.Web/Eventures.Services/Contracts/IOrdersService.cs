using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventures.Services.Contracts
{
    public interface IOrdersService
    {
        Task CreateOrderAsync<T>(T model, string userId);

        IEnumerable<T> GetAllOrders<T>();
    }
}
