using System.Linq;
using PandaWebApp.Models;
using PandaWebApp.ViewModels.Home;
using PandaWebApp.ViewModels.Packages;

namespace PandaWebApp.Controllers
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

                viewModel.Pending = this.Db.Packages.Where(x => x.Recipient.Username == this.User.Username && x.Status == Status.Pending)
                    .Select(x => new BasePackageViewModel
                    {
                        Id = x.Id,
                        Description = x.Description
                    }
                   ).ToList();

                viewModel.Shipped = this.Db.Packages.Where(x => x.Recipient.Username == this.User.Username && x.Status == Status.Shipped)
                    .Select(x => new BasePackageViewModel()
                    {
                        Id = x.Id,
                        Description = x.Description
                    }).ToList();

                viewModel.Delivered = this.Db.Packages.Where(x => x.Recipient.Username == this.User.Username && x.Status == Status.Delivered)
                    .Select(x => new BasePackageViewModel()
                    {
                        Id = x.Id,
                        Description = x.Description
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
