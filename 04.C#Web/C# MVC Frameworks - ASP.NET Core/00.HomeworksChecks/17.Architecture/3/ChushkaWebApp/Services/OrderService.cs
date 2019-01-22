namespace EventWebApp.Services
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Models.Orders;

    [Authorize]
    public class OrderService : PageModel, IOrderService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private readonly IEventService eventService;

        public OrderService(ApplicationDbContext db, IMapper mapper,IEventService eventService)
        {
            this.db = db;
            this.mapper = mapper;
            this.eventService = eventService;
        }


        public IActionResult CreateOrder(OrderViewModel model)
        {
           
            var order = new Order()
            {
                Id = new Guid(),
                CustomerId = model.CustomerId,
                EventId = model.EventId,
                TicketsCount = model.TicketsCount,
                OrderedOn = DateTime.UtcNow
            };

            var evento = this.eventService.GetEventById(model.EventId.ToString());
            evento.TotalTickets -= model.TicketsCount;

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            return this.RedirectToAction("My","Events");

        }


        public OrderListViewModel[] GetAllOrders()
        {
            //var orders = this.db.Orders
            //                .Select(x => new OrderListViewModel()
            //                {
            //                    Customer = x.Customer.UserName,
            //                    Event = x.Event.Name,
            //                    OrderedOn = x.OrderedOn
            //                }
            //  ).ToArray();

            var orders = this.db.Orders.ToArray();
            var ordersViewModel = this.mapper.Map<Order[], OrderListViewModel[]>(orders);

            return ordersViewModel;
        }

        public Order GetOrderById(string id)
        {
            throw new System.NotImplementedException();
        }



        public IActionResult EditOrder(OrderViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult DeleteOrder(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}

