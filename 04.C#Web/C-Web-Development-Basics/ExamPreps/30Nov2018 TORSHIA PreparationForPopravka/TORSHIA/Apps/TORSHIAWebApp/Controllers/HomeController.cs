using System.Linq;
using SIS.HTTP.Responses;
using TORSHIAWebApp.ViewModels.Home;
using TORSHIAWebApp.ViewModels.Tasks;

namespace TORSHIAWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var viewModel = new LoggedInIndexViewModel();

                viewModel.Tasks = this.Db.Tasks.Where(
                        x => x.Participants.Any(f => f.User.Username == this.User.Username))
                    .Select(x => new BaseTaskViewModel()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Level = 5
                    }).ToList();

                var ids = viewModel.Tasks.Select(x => x.Id).ToList();
                ids = ids.Concat(viewModel.Tasks.Select(x => x.Id)).ToList();
                ids = ids.Distinct().ToList();

                viewModel.Tasks = this.Db.Tasks.Where(x => !ids.Contains(x.Id))
                    .Select(x => new BaseTaskViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Level = x.AffectedSectors.Count(),
                    }).ToList();

                return this.View("Home/LoggedInIndex", viewModel);
            }

            return this.View();
        }
    }
}
