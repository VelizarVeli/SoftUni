using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eventures.Web.Controllers
{
    public class OrdersController : Controller
    {
        private IOrdersService ordersService;

        private IEventsService eventsService;

        private UserManager<EventuresUser> userManager;

        public OrdersController(IOrdersService ordersService, IEventsService eventsService, UserManager<EventuresUser> userManager)
        {
            this.ordersService = ordersService;
            this.eventsService = eventsService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                await this.ordersService.CreateOrderAsync<CreateOrderBindingModel>(model, userId);

                return RedirectToAction("MyEvents", "Events");
            }

            return RedirectToAction("All", "Events");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var model = this.ordersService.GetAllOrders<OrderViewModel>();

            return View(model);
        }
    }
}
