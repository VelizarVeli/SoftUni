using EVENTURES.App.ViewModels;
using EVENTURES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Services.Contracts
{
    public interface IEventServices
    {
        void AddEvent(CreateEventViewModel model);

        ICollection<Event> GetAllEvents();
    }
}
