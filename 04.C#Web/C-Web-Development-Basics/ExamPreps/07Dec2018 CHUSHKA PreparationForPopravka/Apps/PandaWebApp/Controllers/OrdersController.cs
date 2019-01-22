using System;
using System.Linq;
using ChushkaWebApp.Models;
using ChushkaWebApp.ViewModels.Orders;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace ChushkaWebApp.Controllers
{
    public class OrdersController : BaseController
    {
        [Authorize]
        public IHttpResponse Order(int id)
        {

            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (user == null)
            {
                return this.BadRequestError("Invalid user.");
            }

            var order = new Order
            {
                OrderedOn = DateTime.UtcNow,
                ProductId = id,
                ClientId = user.Id,
            };

            this.Db.Orders.Add(order);
            this.Db.SaveChanges();

            return this.Redirect("/");
        }

        [Authorize("Admin")]
        public IHttpResponse All()
        {
            var allOrders = this.Db.Orders.Select(x =>
                new OrderViewModel
                {
                    Id = x.Id,
                    Username = x.Client.Username,
                    ProductName = x.Product.Name,
                    OrderedOn = x.OrderedOn
                }).ToList();

            var model = new AllOrdersViewModel() { All = allOrders };
            return this.View(model);
        }
    }
}
