using AutoMapper;
using Eventures.Data;
using Eventures.Mapping;
using Eventures.Services.Contracts;
using Eventures.Services.Models.Events;
using Eventures.Web.Filters;
using Eventures.Web.Models.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using X.PagedList;

namespace Eventures.Web.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;
        private readonly IOrdersService _ordersService;
        private readonly ILogger<EventsController> _logger;
        private readonly EventuresDbContext _dbContext;
        private readonly IMapper mapper;

        public EventsController(IEventsService eventsService, 
            IOrdersService ordersService, 
            ILogger<EventsController> logger, 
            EventuresDbContext dbContext, 
            IMapper mapper)
        {
            this._eventsService = eventsService;
            this._ordersService = ordersService;
            this._logger = logger;
            this._dbContext = dbContext;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [ServiceFilter(typeof(EventsCreateLogActionFilter))]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateEventsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

           await this._eventsService.CreateAsync(model.Name, model.Start, model.End, model.Place, model.TotalTickets, model.PricePerTicket);

            this._logger.LogInformation($"Event created: {model.Name}", model);

            return this.RedirectToAction(nameof(All));            
        }
        
        [Authorize]
        public IActionResult All(int? page)
        {
            var events = this._eventsService.AllByStart()
                .Where(e => e.TotalTickets > 0)
                .Select(e => new AllEventsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    Place = e.Place
                })
                .ToList();


            var nextPage = page ?? 1;
            var pagedViewModel = events.ToPagedList(nextPage, 3);

            return this.View(pagedViewModel);
        }
        
        public IActionResult MyEvents()
        {
            var events = this._dbContext
                        .Orders.Where(o => o.Customer.UserName == this.User.Identity.Name)
                        .Select(o => new EventWithTicketsCountViewModel
                        {
                            Name = o.EventureEvent.Name,
                            TicketsCount = o.TicketCount,
                            Start = o.EventureEvent.Start,
                            End = o.EventureEvent.End
                        }).ToList();

            return this.View(events);            
        }
    }
}
