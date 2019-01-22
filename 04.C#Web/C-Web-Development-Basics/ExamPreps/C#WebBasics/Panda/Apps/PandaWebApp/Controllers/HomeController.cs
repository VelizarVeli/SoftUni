using System.Linq;
using PandaWebApp.ViewModels.Home;

namespace PandaWebApp.Controllers
{
    using SIS.HTTP.Responses;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            //if (this.User.IsLoggedIn)
            //{
            //    var packages = this.Db.Packages.Select(
            //        x => new PackageViewModel
            //        {
            //           Description = x.Description,
            //            Status = x.Status
            //        }).ToList();
            //    var model = new IndexViewModel
            //    {
            //        Packages = packages
            //    };

            //    return this.View("Home/IndexLoggedIn", model);
            //}

            return this.View();
        }
    }
}
