using Eventures.Models.ViewModels.Event;
using System;
using System.Collections.Generic;

namespace Eventures.Services.Contracts
{
    public interface IEventService
    {
        void Create(string name, string place, DateTime startDate, DateTime endDate, int tickets, decimal price);

        IEnumerable<EventListViewModel> All();
    }
}
