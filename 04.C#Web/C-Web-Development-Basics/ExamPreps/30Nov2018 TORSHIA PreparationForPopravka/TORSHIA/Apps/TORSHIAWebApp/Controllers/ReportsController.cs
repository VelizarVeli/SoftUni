using System.Linq;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TORSHIAWebApp.ViewModels.Reports;

namespace TORSHIAWebApp.Controllers
{
    public class ReportsController : BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse All()
        {
            var reports = this.Db.Reports.Select(x =>
                new ReportViewModel
                {
                    Title = x.Task.Title,
                    //TODO: calculate the Level
                    Level = 5,
                    Status = x.Status
                }).ToList();

            var model = new AllReportsViewModel { Reports = reports };
            return this.View(model);
        }
    }
}
