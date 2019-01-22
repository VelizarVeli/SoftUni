using System.Collections.Generic;
using ChushkaWebApp.ViewModels.Products;

namespace ChushkaWebApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
