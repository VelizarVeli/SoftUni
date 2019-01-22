using System.ComponentModel.DataAnnotations;

namespace MusakaWebApp.ViewModels.Products
{
   public class ProductsViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        [MaxLength(12), MinLength(12)]
        public long Barcode { get; set; }

        public string Picture { get; set; }
    }
}
