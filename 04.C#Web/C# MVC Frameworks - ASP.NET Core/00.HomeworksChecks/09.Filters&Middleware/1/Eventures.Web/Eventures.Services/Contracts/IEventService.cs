namespace Eventures.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IEventService
    {
        ICollection<T> All<T>();

        bool Create(string name, string place, DateTime start, DateTime end, int totalTickets, decimal ticketPrice);
    }
}
