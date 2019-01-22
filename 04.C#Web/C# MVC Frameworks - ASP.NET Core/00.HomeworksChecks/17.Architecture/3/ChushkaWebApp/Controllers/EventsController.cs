namespace EventWebApp.Controllers
{
    using System.Linq;
    using Data.Models;
    using Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Events;
    using Services.Contracts;
    using X.PagedList;


    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        // private readonly ILogger logger;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
            // this.logger = logger;
        }

        [Authorize]
        public IActionResult All(int? page)
        {
            var allEvents = this.eventService.GetAllEvents();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            IPagedList<EventViewModel> model = allEvents.ToPagedList(pageNumber, 5); // will only contain 5 products max because of the pageSize
            
            return this.View(model);
        }

        [Authorize]
        public IActionResult My()
        {
            var model = this.eventService.GetMyEvents(this.User.Identity.Name);
            return this.View(model);
        }

        [Authorize("Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [TypeFilter(typeof(LogActionFilter))]
        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Create(EventViewModel model)
        {
            //var.1 - handling binding errors 
            //if (this.ModelState.IsValid)
            //{
            //    return this.eventService.CreateEvent(model);
            //}

            //return this.View((object) model);

            //var.2 - throw exceptions and handle them with error handlers
            if (!this.ModelState.IsValid)
            {
                var messages = string.Join("; ", this.ModelState.Values
                                                              .SelectMany(x => x.Errors)
                                                              .Select(x => x.ErrorMessage));
                var errorViewModel = new ErrorViewModel()
                {
                    Description = messages
                };
                return this.View("_Error", errorViewModel);
            }


            return this.eventService.CreateEvent(model);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var eventById = this.eventService.GetEventById(id);
            if (eventById == null)
            {
                return this.BadRequest("Invalid event id");
            }

            return this.View(eventById);
        }

        [Authorize("Admin")]
        public IActionResult Delete(string id)
        {
            Event product = this.eventService.GetEventById(id);
            var viewModel = new EventViewModel
            {
                //todo: add deleting functionality
            };

            return this.View(viewModel);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Delete(EventViewModel model)
        {
            return this.eventService.DeleteEvent(model.Id.ToString());
        }

        [Authorize("Admin")]
        public IActionResult Edit(string id)
        {
            var evento = this.eventService.GetEventById(id);
            var viewModel = new EventViewModel
            {
                //todo: edit props for changing
            };

            return this.View(viewModel);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Edit(EventViewModel model)
        {
            return this.eventService.EditEvent(model);
        }
    }
}