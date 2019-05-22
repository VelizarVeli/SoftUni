using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
    }
}