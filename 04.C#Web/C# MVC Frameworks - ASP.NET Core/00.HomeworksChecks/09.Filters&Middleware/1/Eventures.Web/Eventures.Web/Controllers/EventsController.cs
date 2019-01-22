using Castle.Core.Logging;
using Eventures.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Eventures.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using ViewModels.Events;

    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        private readonly ILogger<EventsController> logger;

        public EventsController(IEventService eventService, ILogger<EventsController> logger)
        {
            this.eventService = eventService;
            this.logger = logger;
        }

        [Authorize]
        public IActionResult All()
        {
            var eventModels = this.eventService.All<EventInfoViewModel>();
            return this.View(eventModels);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(EventsCreateLogActionFilter))]
        public IActionResult Create(EventCreateViewModel eventCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(eventCreateViewModel);
            }

            var isCreated = this.eventService.Create(eventCreateViewModel.Name, eventCreateViewModel.Place,
                eventCreateViewModel.Start, eventCreateViewModel.End, eventCreateViewModel.TotalTickets,
                eventCreateViewModel.TicketPrice);

            if (!isCreated)
            {
                return this.View();
            }

            this.logger.LogInformation($"Event created: {eventCreateViewModel.Name}", eventCreateViewModel);
            return this.RedirectToAction(nameof(All));
        }
    }
}