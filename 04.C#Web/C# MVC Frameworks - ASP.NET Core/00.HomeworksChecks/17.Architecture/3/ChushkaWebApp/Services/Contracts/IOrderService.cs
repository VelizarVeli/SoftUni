namespace EventWebApp.Services.Contracts
{
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Models.Orders;

    public interface IOrderService
    {
        OrderListViewModel[] GetAllOrders();

        Order GetOrderById(string id);

        IActionResult CreateOrder(OrderViewModel model);

        IActionResult EditOrder(OrderViewModel model);

        IActionResult DeleteOrder(string id);

    }
}
