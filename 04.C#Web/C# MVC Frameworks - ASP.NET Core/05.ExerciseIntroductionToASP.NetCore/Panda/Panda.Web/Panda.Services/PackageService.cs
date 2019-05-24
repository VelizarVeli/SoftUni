using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Panda.Common.ViewModels.Packages;
using Panda.Data;
using Panda.Model;
using Panda.Model.Enums;
using Panda.Services.Contracts;

namespace Panda.Services
{
    public class PackageService : BaseService, IPackageService
    {
        public PackageService(PandaDbContext db, UserManager<PandaUser> userManager)
            : base(db, userManager)
        {
        }

        public async Task<PackagesViewModel> AllPackages(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            var viewModel = new PackagesViewModel();
            var currentUserPackages = Db.Packages.Where(u => u.RecipientId == id);
            if (user != null)
            {
                viewModel.PendingPackages = currentUserPackages
                    .Where(s => s.Status == Status.Pending && s.RecipientId == user.Id)
                    .Select(x => new PackageViewModel
                    {
                        Id = x.Id,
                        Name = x.Description
                    });

                viewModel.ShippedPackages = currentUserPackages
                    .Where(s => s.Status == Status.Shipped && s.RecipientId == user.Id)
                    .Select(x => new PackageViewModel
                    {
                        Id = x.Id,
                        Name = x.Description
                    });

                viewModel.DeliveredPackages = currentUserPackages
                    .Where(s => s.Status == Status.Delivered && s.RecipientId == user.Id)
                    .Select(x => new PackageViewModel
                    {
                        Id = x.Id,
                        Name = x.Description
                    });
            }

            return viewModel;
        }

        public async Task<PackageDetailsViewModel> Details(Guid id, string userId)
        {
            var currentPackage = await Db.Packages.FirstOrDefaultAsync(i => i.Id == id);
            var currentUsername = await UserManager.FindByIdAsync(userId);
            var viewModel = new PackageDetailsViewModel
            {
                Address = currentPackage.ShippingAddress,
                Status = currentPackage.Status,
                EstimatedDeliveryDate = currentPackage.EstimatedDeliveryDate,
                Weight = currentPackage.Weight,
                Recipient = currentUsername.UserName,
                Description = currentPackage.Description
            };
            return viewModel;
        }

        public CreatePackageViewModel GetUserNamesPackage()
        {
            var allUserNames = UserManager.Users;
            var viewModel = new CreatePackageViewModel();
            foreach (var usery in allUserNames)
            {
                viewModel.Recipients.Add(usery.UserName);
            }

            return viewModel;
        }

        public async Task CreatePackage(CreatePackageViewModel model)
        {
            var recipient = Db.Users.FirstOrDefault(u => u.UserName == model.Recipient);

            var package = new Package
            {
                Description = model.Description,
                Weight = model.Weight,
                ShippingAddress = model.Address,
                Status = Status.Pending,
                RecipientId = recipient.Id
            };
            Db.Packages.Add(package);
            await Db.SaveChangesAsync();
        }
    }
}