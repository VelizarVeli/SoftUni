using System.Linq;
using MusakaWebApp.Models;
using MusakaWebApp.ViewModels.Home;
using SIS.HTTP.Responses;

namespace MusakaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var products = this.Db.Products.Select(
                    x => new ProductViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                    }).ToList();
                var model = new IndexViewModel
                {
                    Products = products,
                    Total = products.Sum(x => x.Price)
                };

                return this.View("Home/LoggedIn-Index", model);
            }

            return this.View();
        }
    }
}
