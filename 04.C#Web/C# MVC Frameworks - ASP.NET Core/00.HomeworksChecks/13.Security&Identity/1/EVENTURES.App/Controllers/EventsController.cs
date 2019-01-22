using EVENTURES.App.Services.Contracts;
using EVENTURES.App.ViewModels;
using EVENTURES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Controllers
{
    public class EventsController : Controller
    {
        private IOrderServices orderService;
        private IEventServices eventService;
        private UserManager<EvUser> _userManager;

        public EventsController(IEventServices eventService, IOrderServices orderService, UserManager<EvUser> userManager)
        {
            this.eventService = eventService;
            this.orderService = orderService;
            this._userManager = userManager;
        }

        //[HttpPost]
        [Authorize]
        public async Task<IActionResult> My()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var myEvents = this.orderService.FindMyEvents(user.Id).ToList();


            return View(myEvents);
        }

        public IActionResult All()
        {
            var events = this.eventService.GetAllEvents();

            var eventsViewmodels = new List<CreateEventViewModel>();
            foreach (var item in events)
            {
                eventsViewmodels.Add(new CreateEventViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Start = item.Start,
                    End = item.End,
                    Place = item.Place
                });
            }

            return View(eventsViewmodels);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateEventViewModel model)
        {
            this.eventService.AddEvent(model);
            return RedirectToAction("Index", "Home");
        }
    }
}

