using System.Collections.Generic;
using ChushkaWebApp.ViewModels.Products;

namespace ChushkaWebApp.ViewModels.Home
{
    public class LoggedInIndexViewModel
    {
        public IEnumerable<BaseProductViewModel> Products { get; set; }
    }
}
