using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyChushka.WebApp.Constants;
using MyChushka.WebApp.Data;
using MyChushka.WebApp.Models;
using MyChushka.WebApp.ViewModels.Orders;

namespace MyChushka.WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext db;

        public OrdersController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        public IActionResult Order(int productId)
        {
            var currentUser = this.db.Users
                .FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var order = new Order
            {
                ClientId = currentUser.Id,
                ProductId = productId,
                OrderedOn = DateTime.UtcNow,
            };

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            var model = this.db.Products.FirstOrDefault(p => p.Id == productId);

            return this.View(model);
        }

        [Authorize(Roles = MyConst.AdminRole)]
        public IActionResult All()
        {
            var model = this.db.Orders
                .Select(o => new AllOrdersViewModel
                {
                    Id = o.Id,
                    OrderedOn = o.OrderedOn,
                    CustomerName = o.Client.FullName,
                    ProductName = o.Product.Name
                })
                .ToList();

            return this.View(model);
        }
    }
}