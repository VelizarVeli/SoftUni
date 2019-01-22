using System.Collections.Generic;

namespace PandaWebApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<PackageViewModel> Packages { get; set; }
    }
}
