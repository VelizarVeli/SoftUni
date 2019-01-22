using System.Linq;
using ChushkaWebApp.ViewModels.Home;
using ChushkaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;

namespace ChushkaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (user != null)
            {
                var viewModel = new LoggedInIndexViewModel();
                viewModel.Products = Db.Products.Select(x => new BaseProductViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Price = x.Price
                    }).ToList();

                return this.View("Home/LoggedIn-Index", viewModel);
            }
            else
            {
                return this.View();
            }
        }
    }
}
