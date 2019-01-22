namespace EventWebApp.Controllers
{
    using System.Linq;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Orders;
    using Services.Contracts;

    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEventService eventService;

        public OrdersController(IOrderService orderService,UserManager<ApplicationUser> userManager, IEventService eventService)
        {
            this.orderService = orderService;
            this.userManager = userManager;
            this.eventService = eventService;
        }

        // GET: Orders
        [Authorize("Admin")]
        public ActionResult All()
        {
            var orders = this.orderService.GetAllOrders();

            return this.View(orders);
        }


        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(OrderViewModel model)
        {


            var availableTickets = this.eventService.GetEventById(model.EventId.ToString()).TotalTickets;

            if (availableTickets < model.TicketsCount)
            {
                this.ModelState.AddModelError("AvailableTickets",$"There are not enough tickets! Available tickets are {availableTickets}");
                //this.TempData.Add("Error", $"There are not enough tickets! Available tickets are {availableTickets}");

                //return this.RedirectToAction("All", "Events", model);
            }

            if (!this.ModelState.IsValid)
            {
                var errors = this.ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage).ToList();

                return this.View("_Error", errors);
            }


            var user = this.userManager.GetUserAsync(this.User).Result;
            model.CustomerId = user.Id;
            model.Customer = user;
            return this.orderService.CreateOrder(model);
        }
    }
}