using System.Collections.Generic;
using PandaWebApp.ViewModels.Packages;

namespace PandaWebApp.ViewModels.Home
{
   public class LoggedInIndexViewModel
    {
        public ICollection<BasePackageViewModel> Pending { get; set; }

        public IEnumerable<BasePackageViewModel> Shipped { get; set; }

        public IEnumerable<BasePackageViewModel> Delivered { get; set; }
    }
}
