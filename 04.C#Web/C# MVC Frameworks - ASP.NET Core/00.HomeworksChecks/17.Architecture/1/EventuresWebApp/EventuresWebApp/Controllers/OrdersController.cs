namespace EventuresWebApp.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Interfaces;
    using Services.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly IOrderService orders;
        private readonly IEventService events;
        private readonly UserManager<EventuresUser> userManager;
        private readonly IMapper mapper;

        public OrdersController(
            IOrderService orders,
            IEventService events,
            UserManager<EventuresUser> userManager,
            IMapper mapper)
        {
            this.orders = orders;
            this.events = events;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Order(string eventId, int ticketsCount)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if (ticketsCount > 0 && events.Exists(eventId))
            {
                var ticketsLeft = this.events.TicketsLeftById(eventId);
                if (ticketsLeft < ticketsCount)
                {
                    return this.RedirectToAction("All", "Events", new {ErrorMessage = $"There are only {ticketsLeft} tickets left for this event."});
                }

                this.orders.Order(eventId, user.Id, ticketsCount);
                this.events.ReduceTicketsLeftCount(eventId, ticketsCount);
            }

            return this.RedirectToAction("My", "Events");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult All()
        {
            var allOrdersViewModel = new AllOrdersViewModel()
            {
                Orders = mapper.Map<AdminOrderModel[], IEnumerable<OrderViewModel>>(this.orders.All().ToArray())
            };

            return View(allOrdersViewModel);
        }
    }
}