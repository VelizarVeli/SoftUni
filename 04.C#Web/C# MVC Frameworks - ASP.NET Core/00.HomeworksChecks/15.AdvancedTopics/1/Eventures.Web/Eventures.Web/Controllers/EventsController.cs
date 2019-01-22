using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.Filters;
using Eventures.Web.ViewModels.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Eventures.Web.Controllers
{
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;

        private readonly ILogger logger;

        public EventsController(IEventsService eventsService, ILoggerFactory loggerFactory)
        {
            this.eventsService = eventsService;
            this.logger = loggerFactory.CreateLogger(typeof(EventsController));
        }

        public IActionResult All()
        {
            var model = this.eventsService.GetAllAvailableEvents<EventViewModel>();

            return View(model);
        }

        [Authorize(Roles = ("Admin"))]
        public IActionResult Create()
        {
            return View();
        }

        [ServiceFilter(typeof(LogEventCreateActionFilter))]
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<IActionResult> Create(CreateEventBindingModel model)
        {
            if (ModelState.IsValid)
            {
                await this.eventsService.CreateEventAsync(model);

                logger.LogInformation($"--- Event created: {model.Name} ---");

                return RedirectToAction("All", "Events");
            }

            return View();
        }

        [Authorize]
        public IActionResult MyEvents()
        {
            var model = this.eventsService.GetMyEvents<MyEventViewModel>(this.User.Identity.Name);

            return View(model);
        }
    }
}

