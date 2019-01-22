using System.Linq;
using PandaWebApp.ViewModels.Packages;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers
{
    public class PackagesController : BaseController
    {
        [Authorize]
        public IHttpResponse PackageDetails(int id)
        {
            var model = this.Db.Packages.FirstOrDefault(x => x.Id == id);
            string date = string.Empty;
            if (model.Status.ToString() == "Pending")
            {
                date = "N/A";
            }
            else if (model.Status.ToString() == "Delivered" || model.Status.ToString() == "Acquired")
            {
                date = "Delivered";
            }
            else
            {
                date = model.EstimatedDeliveryDate.ToString();
            }

            var viewModel = this.Db.Packages
                .Select(x => new PackageDetailsViewModel
                {
                    Address = x.ShippingAddress,
                    Status = x.Status,
                    EstimatedDeliveryDate = date,
                    Weight = x.Weight,
                    Recipient = x.Recipient,
                    Description = x.Description
                });

            return this.View(viewModel);
        }
    }
}
