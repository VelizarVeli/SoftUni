namespace EventuresWebApp.Web.Controllers
{
    using AutoMapper;
    using Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;  
    using Models;
    using Services.Interfaces;
    using Services.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ViewModels.Events;

    public class EventsController : Controller
    {
        private const int PageSize = 5;

        private readonly IEventService events;
        private readonly IOrderService orders;
        private readonly UserManager<EventuresUser> userManager;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public EventsController(
            IEventService events, 
            IOrderService orders,
            UserManager<EventuresUser> userManager,
            ILogger<EventsController> logger,
            IMapper mapper)
        {
            this.events = events;
            this.orders = orders;
            this.userManager = userManager;
            this.logger = logger;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult All(string errorMessage, int page = 1)
        {
            var eventsViewModel = new AllEventsViewModel
            {
                Events = mapper.Map<EventModel[], IEnumerable<EventViewModel>>(this.events.All(page, PageSize).ToArray()),
                TotalPages = (int)Math.Ceiling(this.events.Count() / (double)PageSize),
                CurrentPage = page,
                PageSize = PageSize,
                ErrorMessage = errorMessage
            };

            return View(eventsViewModel);
        }

        [Authorize]
        public async Task<IActionResult> My()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var eventsViewModel = new AllEventsViewModel
            {
                Events = mapper.Map<OrderModel[], IEnumerable<EventViewModel>>(this.orders.ByUserId(user.Id).ToArray())
            };

            return View(eventsViewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [ServiceFilter(typeof(LogAdminActivityActionFilter))]
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Create(CreateEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.events.Create(
                model.Name,
                model.Place,
                model.Start,
                model.End,
                model.TotalTickets,
                model.PricePerTicket);

            this.logger.LogInformation("Event created: " + model.Name);

            return this.RedirectToAction("All");
        }
    }
}
