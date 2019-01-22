using System.Linq;
using PandaWebApp.Models;
using PandaWebApp.ViewModels.Receipts;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers
{
    public class ReceiptsController : BaseController
    {
        [Authorize]
        public IHttpResponse Index()
        {
            var receipts = this.Db.Receipts.Where(u => u.Recipient.Username == this.User.Username).Select(x =>
                new ReceiptViewModel
                {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.IssuedOn.ToString("dd/MM/yyyy"),
                    Recipient = x.Recipient.Username,
                }).ToList();

            var model = new AllReceiptsViewModel { Receipts = receipts };
            return this.View(model);
        }


        [Authorize]
        public IHttpResponse CreateReceipt(int packageId)
        {
            var package = this.Db.Packages.FirstOrDefault(u => u.Id == packageId);

            if (package == null)
            {
                return this.BadRequestError("Invalid package id");
            }

            var receipt = new Receipt
            {
                Fee = (decimal)package.Weight * 2.67m,
                Package = package
            };

            this.Db.Receipts.Add(receipt);
            this.Db.SaveChanges();

            return this.Redirect("/Receipts/Details?id=" + receipt.Id);
        }

        [Authorize]
        public IHttpResponse Details(int id)
        {
            var viewModel = this.Db.Receipts
                .Select(x => new ReceiptDetailsViewModel()
                {
                    Id = x.Id,
                    IssuedOn = x.IssuedOn.ToString("dd/MM/yyyy"),
                    DeliveryAddress = x.Package.ShippingAddress,
                    PackageWeight = x.Package.Weight,
                    PackageDescription = x.Package.Description,
                    Recipient = x.Recipient.Username,
                    Fee = x.Fee,
                })
                .FirstOrDefault(x => x.Id == id);
            if (viewModel == null)
            {
                return this.BadRequestError("Invalid product id.");
            }

            return this.View(viewModel);
        }
    }
}