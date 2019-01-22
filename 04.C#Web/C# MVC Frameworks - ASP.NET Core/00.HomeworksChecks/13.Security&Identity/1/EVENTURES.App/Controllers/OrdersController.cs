using EVENTURES.App.Services.Contracts;
using EVENTURES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderServices orderService;
        private UserManager<EvUser> _userManager;

        public OrdersController(IOrderServices orderService, UserManager<EvUser> userManager)
        {
            this.orderService = orderService;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Create(Guid id, int tickets)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            this.orderService.AddOrder(id, tickets, user);

            return this.RedirectToAction("Index", "Home");
        }

        
        public IActionResult All()
        {
            var orders = this.orderService.AllOrders().ToList();

            return View(orders);
        }
    }
}
