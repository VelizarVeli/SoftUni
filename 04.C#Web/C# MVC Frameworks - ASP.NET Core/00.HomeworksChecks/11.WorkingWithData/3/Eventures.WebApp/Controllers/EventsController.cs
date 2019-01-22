namespace Eventures.WebApp.Controllers
{
    using System;
    using System.Linq;
    using Data;
    using Extentions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using Services;
    using ViewModels;

    [Authorize]
    public class EventsController : BaseController
    {
        public EventsController(ApplicationDbContext context, IEventService eventService, ILogger<EventsController> logger)
            : base(context)
        {
            this.Logger = logger;
            this.EventService = eventService;
        }

        private ILogger<EventsController> Logger { get; }

        private IEventService EventService { get; }

        [HttpGet]
        public IActionResult All()
        {
            var events = this.EventService.All();
            return this.View(events);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(LogCreateActionFilter))]
        public IActionResult Create(EventInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.EventService.CreateEvent(model);
            this.Logger.LogInformation($"Event created: {model.Name}, {model}");

            return RedirectToAction(nameof(All));
        }

        public IActionResult PersonalEvents()
        {
            string userName = this.User.Identity.Name;
            var userEvents = this.EventService.UserEvents(userName);

            return this.View(userEvents);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AllOrders()
        {
            var orders = this.EventService.AllOrders();

            return this.View(orders);
        }

        [HttpPost]
        public IActionResult Order(Guid id)
        {
            var tickets = int.Parse(this.Request.Form["Tickets"]);
            var username = this.User.Identity.Name;
            this.EventService.CreateOrder(id, username, tickets);

            return RedirectToAction(nameof(All));
        }
    }
}