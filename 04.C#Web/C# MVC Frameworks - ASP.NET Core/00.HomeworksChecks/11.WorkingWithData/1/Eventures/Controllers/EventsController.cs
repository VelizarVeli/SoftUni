using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Eventures.Filters;
using Eventures.Infrastructure;
using Eventures.Services.Contracts;
using Eventures.ViewModels.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventures.Controllers
{
    public class EventsController : Controller
    {

        private readonly IEventsService eventsService;
        private readonly ILogger<EventsController> logger;

        public EventsController(IEventsService eventsService, ILogger<EventsController> logger)
        {
            this.eventsService = eventsService;
            this.logger = logger;
            ;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
           
            return View();
        }

        [ServiceFilter(typeof(EventsCreateLogActionFilter))]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(CreateEventViewModel model)
        {
            if (!ModelState.IsValid) return this.View(model);

            this.eventsService.Create(model.Name, model.Place, model.Start, model.End, model.TotalTickets, model.PricePerTicket);

            this.logger.LogInformation($"Event created: {model.Name}",model);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult All()
        {

            var events = this.eventsService.All<CreateEventViewModel>();
            return this.View(events);
        }
    }
}