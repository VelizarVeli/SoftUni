using Microsoft.AspNetCore.Mvc;
using MyChushka.WebApp.ViewModels.Orders;

namespace MyChushka.WebApp.Components
{
    public class OrderNodeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(AllOrdersViewModel model)
        {
            return this.View(model);
        }
    }
}