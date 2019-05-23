using System;
using System.Threading.Tasks;
using Panda.Common.ViewModels.Packages;

namespace Panda.Services.Contracts
{
    public interface IPackageService
    {
        Task<PackagesViewModel> AllPackages(string id);
        Task<PackageDetailsViewModel> Details(Guid id, string userId);
        CreatePackageViewModel GetUserNamesPackage();
    }
}