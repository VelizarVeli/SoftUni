using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Eventures.Web.ViewModels;

namespace Eventures.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IDataService dataService;

        public OrdersController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public IActionResult All()
        {
            var model = new List<OrderViewModel>();

            var orders = this.dataService.GetAllOrders();

            foreach (var order in orders)
            {
                var view = new OrderViewModel()
                {
                    EventName = order.Event.Name,
                    Customer = order.Customer.UserName,
                    CreatedOn = order.OrderedOn
                };

                model.Add(view);
            }

            return View(model);
        }
       
        
    }
}
