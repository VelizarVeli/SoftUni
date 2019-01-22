using System.Linq;
using Eventures.Models;

namespace Eventures.Services.Contracts
{
    public interface IOrderService
    {
        void Create(Order reportDb);

        IQueryable<Order> GetAll();

        Event GetEvent(string id);
    }
}