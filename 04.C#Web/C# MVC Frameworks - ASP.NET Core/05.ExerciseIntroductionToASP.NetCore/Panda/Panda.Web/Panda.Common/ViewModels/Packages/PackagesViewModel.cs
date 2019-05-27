using System.Collections.Generic;

namespace Panda.Common.ViewModels.Packages
{
    public class PackagesViewModel
    {
        public IEnumerable<PackageViewModel> PendingPackages { get; set; }
        public IEnumerable<PackageViewModel> ShippedPackages { get; set; }
        public IEnumerable<PackageViewModel> DeliveredPackages { get; set; }
    }
}
