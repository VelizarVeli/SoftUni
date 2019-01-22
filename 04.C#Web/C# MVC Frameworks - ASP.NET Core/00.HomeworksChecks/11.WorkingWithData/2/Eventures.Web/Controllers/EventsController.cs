using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models.ViewModels.Event;
using Eventures.Services.Contracts;
using Eventures.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventures.Web.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IEventService events;
        private readonly ILogger<EventsController> logger;
        public EventsController(IEventService events)
        {
            this.events = events;
        }
        public IActionResult All()
        {
            var eventsList = events.All();

            return View(eventsList);
        }

        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(EventCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            events.Create(model.Name, model.Place, model.Start, model.End, model.Tickets, model.PricePerTicket);
            this.logger.LogInformation("Event created: " + model.Name, model);

            return this.RedirectToAction(nameof(All));
        }
    }
}