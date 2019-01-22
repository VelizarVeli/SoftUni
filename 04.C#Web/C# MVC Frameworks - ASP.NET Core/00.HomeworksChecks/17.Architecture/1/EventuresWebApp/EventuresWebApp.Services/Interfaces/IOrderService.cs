namespace EventuresWebApp.Services.Interfaces
{
    using Models;
    using System.Collections.Generic;  

    public interface IOrderService
    {
        void Order(string eventId, string userId, int ticketsCount);

        IEnumerable<OrderModel> ByUserId(string id);

        IEnumerable<AdminOrderModel> All();
    }
}
