using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eventures.Areas.Events.ViewModels;
using Eventures.Data;
using Eventures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eventures.Areas.Events.Controllers
{
    [Area("Events")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public OrdersController( ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(string id, int ticketCount)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.UserName == this.User.Identity.Name);
            var eventt = dbContext.Events.FirstOrDefault(x => x.Id == id);
            eventt.TotalTickets -= ticketCount;

            var order = new Order
            {
                Customer = user,
                Event = eventt,
                TicketCount = ticketCount
            };
            

            this.dbContext.Orders.Add(order);
            this.dbContext.SaveChanges();

            return RedirectToAction("All", "Events");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult All()
        {
            var orders = this.dbContext.Orders.ToList().Select(x => mapper.Map<OrderViewModel>(x));

            return this.View(orders);
        }
    }
}
