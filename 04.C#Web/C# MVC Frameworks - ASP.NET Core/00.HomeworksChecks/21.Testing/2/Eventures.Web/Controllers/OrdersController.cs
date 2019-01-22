using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.Filters;
using Eventures.Web.Models;
using Eventures.Web.Structures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService service;
        private readonly UserManager<EventureUser> userManager;
        private readonly IMapper _mapper;
        private readonly string customerId;
        private ClaimsPrincipal principal;

        public OrdersController(IOrderService service, UserManager<EventureUser> userManager, SignInManager<EventureUser> signInManager,IMapper mapper)
        {
            this.service = service;
            this.userManager = userManager;
            _mapper = mapper;
            this.customerId = userManager.GetUserId(signInManager.Context.User);
            this.principal = signInManager.Context.User;

        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> All(int pageIndex = 1)
        {
            var orders = this.service.GetAll().
                ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);

            var model = await PaginatedList<OrderViewModel>.CreateAsync(orders, pageIndex, 5);
                
            return View(model);
        }

        [HttpPost]
        [ServiceFilter(typeof(ActionFilter))]
        public async Task<IActionResult> Order(CreateOrderViewModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            bindingModel.Event = this.service.GetEvent(bindingModel.EventId);
            bindingModel.Customer = await this.userManager.GetUserAsync(principal);
            bindingModel.CustomerId = customerId;

            var order = _mapper.Map<Order>(bindingModel);
            
            
            order.Event.Reports.Add(order);
            order.Customer.Reports.Add(order);
            
            this.service.Create(order);

            return this.Redirect("/Events/MyEvents");
        }
    }
}   