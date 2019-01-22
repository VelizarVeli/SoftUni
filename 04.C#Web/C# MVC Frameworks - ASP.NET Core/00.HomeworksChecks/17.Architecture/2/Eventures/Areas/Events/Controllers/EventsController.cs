namespace Eventures.Areas.Event.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Eventures.Areas.Event.ViewModels;
    using Eventures.Data;
    using Eventures.Filters;
    using Eventures.Services.EventService.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Eventures.Models;
    using AutoMapper;
    using X.PagedList;

    [Authorize]
    [Area("Events")]
    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public EventsController(IEventService eventService, ApplicationDbContext dbContext, ILogger<EventsController> logger, IMapper mapper)
        {
            this.eventService = eventService;
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        [ServiceFilter(typeof(LogUserActivity))]
        [Authorize]
        public IActionResult Index(int? page)
        {
            var events = this.eventService.All();
            var viewModels = new List<EventViewModel>();
            foreach (var eventModel in events)
            {
                var eventViewModel = mapper.Map<EventViewModel>(eventModel);
                viewModels.Add(eventViewModel);
            }
            var nextPage = page ?? 1;
            var pageViewModels = viewModels.ToPagedList(nextPage, 5);

            return this.View(pageViewModels);
        }

        [Authorize]
        public IActionResult All()
        {
            var events = this.eventService.All().ToList();

            var viewModels = new List<EventViewModel>();
            foreach (var eventModel in events)
            {
                var eventViewModel = mapper.Map<EventViewModel>(eventModel);
                //var eventViewModel = new EventViewModel
                //{
                //    Id = eventModel.Id,
                //    End = eventModel.End,
                //    Name = eventModel.Name,
                //    Place = eventModel.Place,
                //    PricePerTicket = eventModel.PricePerTicket,
                //    Start = eventModel.Start,
                //    TotalTickets = eventModel.TotalTickets
                //};
                viewModels.Add(eventViewModel);
            }
            return View(viewModels);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Create(EventViewModel eventViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Events");
            }

            var eventt = mapper.Map<Event>(eventViewModel);
            //var eventt = new Event
            //{
               
            //    Name = eventViewModel.Name,
            //    Place = eventViewModel.Place,
            //    End = eventViewModel.End,
            //    Start = eventViewModel.Start,
            //    PricePerTicket = eventViewModel.PricePerTicket,
            //    TotalTickets = eventViewModel.TotalTickets
            //};

            this.dbContext.Events.Add(eventt);
            this.dbContext.SaveChanges();

            this.logger.LogInformation("Event created: " + eventt.Name, eventt);

            return this.RedirectToAction("All", "Events");
        }

        [Authorize()]
        public IActionResult MyEvents()
        {
            var events = this.dbContext.Orders
                .Where(x => x.Customer.UserName == this.User.Identity.Name)
                .ToList()
                .Select(x => mapper.Map<Order, EventViewModel>(x));

            return this.View(events);
        }
    }
}