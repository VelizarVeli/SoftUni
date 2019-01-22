using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using Eventures.Web.Filters;
using Eventures.Web.Services;
using Eventures.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Eventures.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IDataService _dataService;
        private readonly ILogger<EventsController> logger;

        public EventsController(IDataService dataService, ILogger<EventsController> logger)
        {
            _dataService = dataService;
            this.logger = logger;
        }

        [Authorize]
        public IActionResult All()
        {
            var events = this._dataService.GetAllEvents();
            var model = events.Select(ev => new EventViewModel()
            {
                Name = ev.Name, Start = ev.Start, End = ev.End, Id = ev.Id

            }).ToList();

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [TypeFilter(typeof(LogAdminActivityFilter))]
        public IActionResult Create(CreateEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                this._dataService.CreateEvent(model);
                                
                logger.LogInformation($"Event created: {model.Name}");
            }
            else
            {
                return this.View(model);
            }
            

            return this.RedirectToAction("All", "Events");
        }

        [Authorize]
        [HttpPost]
        public IActionResult OrderTickets()
        {           
            //return this.View("Error", new ErrorViewModel() { ErrorMessage = "Tickets must be an integer!" });
            
            int ticketsCount = 0;
            if (!int.TryParse(this.HttpContext.Request.Form["ev.TicketsOrdered"].FirstOrDefault(), out ticketsCount))
            {
                return this.View("Error", new ErrorViewModel() { ErrorMessage = "Tickets must be an integer!" });
            }

            var eventId = int.Parse(this.HttpContext.Request.Form["ev.Id"].FirstOrDefault());
            var customer = this.User.Identity.Name;

            this._dataService.OrderTicketsForEvent(eventId, ticketsCount, customer);
            
            return RedirectToAction("MyEvents", "Users");
        }
    }
}