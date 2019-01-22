namespace Eventures.WebApp.Services
{
    using System;
    using System.Collections.Generic;
    using ViewModels;

    public interface IEventService
    {
        IEnumerable<EventOutputModel> All();

        void CreateEvent(EventInputModel model);

        IEnumerable<EventOutputModel> UserEvents(string userName);

        IEnumerable<OrderOutputModel> AllOrders();

        void CreateOrder(Guid id, string name, int tickets);
    }
}