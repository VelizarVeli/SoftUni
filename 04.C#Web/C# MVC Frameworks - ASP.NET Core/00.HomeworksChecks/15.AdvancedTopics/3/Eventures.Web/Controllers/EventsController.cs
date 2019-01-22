using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using Eventures.Models.ViewModels;
using Eventures.Services.Interfaces;
using Eventures.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class EventsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEventService eventService;

        public EventsController(IEventService eventService, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.eventService = eventService;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var allEvents = await this.eventService.GetAllEventsAsync();

            return this.View(allEvents.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [TypeFilter(typeof(LogEventFilter))]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateViewModel model)
        {
            if(!ModelState.IsValid) return this.View(model);

            this.eventService.CreateEvent(model);

            return this.RedirectToAction("All");
        }

        [Authorize]
        public async Task<IActionResult> MyEvents()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var events = this.eventService.GetMyEvents(user).ToList();

            return this.View(events);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Order(int tickets, Guid eventId)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                var userId = await this.userManager.GetUserIdAsync(user);
                var ticketsLeft = this.eventService.GetTicketsLeft(eventId);

                if (ticketsLeft - tickets >= 0)
                {
                    this.eventService.Order(tickets, userId, eventId);

                    return this.RedirectToAction("MyEvents");
                }

                this.ViewData["Message"] = $"Only {ticketsLeft} tickets left for this event!";

                return this.View("Error");

            }

            return this.RedirectToAction("All");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllOrders()
        {
            var orders = this.eventService.GetAllOrders();

            return this.View(orders.ToList());
        }
    }
}
