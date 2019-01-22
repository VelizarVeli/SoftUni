using System;
using System.Linq;
using PandaWebApp.Models;
using PandaWebApp.ViewModels.Packages;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers
{
    public class PackagesController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var viewModel = this.Db.Packages
                .Select(x => new PackageDetailsViewModel
                {
                    ShippingAddress = x.ShippingAddress,
                    EstimatedDeliveryDate = x.EstimatedDeliveryDate.ToString("dd/MM/yyyy"),
                    Id = x.Id,
                    Status = x.Status,
                    Weight = x.Weight,
                    Recipient = x.Recipient.Username,
                    Description = x.Description,
                })
                .FirstOrDefault(x => x.Id == id);
            if (viewModel == null)
            {
                return this.BadRequestError("Invalid package id.");
            }

            if (viewModel.Status == Status.Pending)
            {
                viewModel.EstimatedDeliveryDate = "N/A";
            }
            else if (viewModel.Status == Status.Acquired || viewModel.Status == Status.Delivered)
            {
                viewModel.EstimatedDeliveryDate = "Delivered";
            }

            return this.View(viewModel);
        }

        [Authorize("Admin")]
        public IHttpResponse Pending()
        {
            var pendingPackages = this.Db.Packages.Where(s => s.Status == Status.Pending).Select(x =>
                new Pending()
                {
                    Id = x.Id,
                    Address = x.ShippingAddress,
                    Weight = x.Weight,
                    Recipient = x.Recipient.Username,
                    Description = x.Description
                }).ToList();

            var model = new AllPackagesViewModel() { Pending = pendingPackages };
            return this.View(model);
        }

        [Authorize("Admin")]
        public IHttpResponse Shipped()
        {
            var shippedPackages = this.Db.Packages.Where(s => s.Status == Status.Shipped).Select(x =>
                new Shipped
                {
                    Id = x.Id,
                    Address = x.ShippingAddress,
                    Weight = x.Weight,
                    Recipient = x.Recipient.Username,
                    Description = x.Description,
                    EstimatedDate = x.EstimatedDeliveryDate.ToString("dd/MM/yyyy")
                }).ToList();

            var model = new AllPackagesViewModel() { Shipped = shippedPackages };
            return this.View(model);
        }

        [Authorize("Admin")]
        public IHttpResponse Delivered()
        {
            var deliveredPackages = this.Db.Packages.Where(s => s.Status == Status.Delivered).Select(x =>
                new Delivered
                {
                    Id = x.Id,
                    Address = x.ShippingAddress,
                    Weight = x.Weight,
                    Recipient = x.Recipient.Username,
                    Description = x.Description
                }).ToList();

            var model = new AllPackagesViewModel() { Delivered = deliveredPackages };
            return this.View(model);
        }

        [Authorize("Admin")]
        public IHttpResponse Ship(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                return this.BadRequestError("Invalid package id.");
            }

            package.Status = Status.Shipped;
            package.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(Random());
            this.Db.SaveChanges();
            return this.Redirect("/Packages/Pending");
        }

        [Authorize("Admin")]
        public IHttpResponse Deliver(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                return this.BadRequestError("Invalid package id.");
            }

            package.Status = Status.Delivered;
            package.EstimatedDeliveryDate = DateTime.UtcNow;
            this.Db.SaveChanges();
            return this.Redirect("/Packages/Shipped");
        }

        [Authorize]
        public IHttpResponse Acquire(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                return this.BadRequestError("Invalid package id.");
            }

            package.Status = Status.Acquired;
            var receipt = new Receipt
            {
                Fee = (decimal)package.Weight * 2.67m,
                RecipientId = package.RecipientId,
                PackageId = id
            };

            this.Db.Receipts.Add(receipt);
            this.Db.SaveChanges();
            return this.Redirect("/Home/LoggedIn-Index");
        }

        private int Random()
        {
            var rnd = new Random();
            int nextDeliveryDate = rnd.Next(20, 40);
            return nextDeliveryDate;
        }

        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Create()
        {
            var recipients = this.Db.Users.Select(u => new RecipientViewModel
                {
                    Username = u.Username
                })
                .ToList();

            var recipientsViewModel = new RecipientsViewModel
            {
                Recipients = recipients
            };

            return this.View("Packages/Create", recipientsViewModel);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(CreatePackageInputModel model)
        {
            var user = this.Db.Users.FirstOrDefault(u => u.Username == model.Recipient);

            if (user == null)
            {
                return this.BadRequestError("Invalid username");
            }

            var package = new Package
            {
               Description = model.Description,
                Weight = model.Weight,
                ShippingAddress = model.ShippingAddress,
                Status = Status.Pending,
                EstimatedDeliveryDate = DateTime.Parse("01/01/1970"),
                Recipient = user
            };

            this.Db.Packages.Add(package);
            this.Db.SaveChanges();

            return this.Redirect("/Packages/Details?id=" + package.Id);
        }
    }
}
