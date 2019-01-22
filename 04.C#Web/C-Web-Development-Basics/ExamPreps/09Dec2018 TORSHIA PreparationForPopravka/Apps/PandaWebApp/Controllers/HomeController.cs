using System.Linq;
using TorshiaWebApp.ViewModels.Home;
using TorshiaWebApp.ViewModels.Tasks;

namespace TorshiaWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (user != null)
            {
                var viewModel = new LoggedInIndexViewModel();
                viewModel.Tasks = this.Db.Tasks
                    .Select(x => new BaseTaskViewModel
                    {
                        Id = x.Id,
                       Name = x.Title,
                        Level = 5
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
