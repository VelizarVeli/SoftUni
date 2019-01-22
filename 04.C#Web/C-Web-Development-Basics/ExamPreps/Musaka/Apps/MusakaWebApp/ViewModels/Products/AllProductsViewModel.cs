using System.Collections.Generic;

namespace MusakaWebApp.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public IEnumerable<ProductsViewModel> Products { get; set; }
    }
}
