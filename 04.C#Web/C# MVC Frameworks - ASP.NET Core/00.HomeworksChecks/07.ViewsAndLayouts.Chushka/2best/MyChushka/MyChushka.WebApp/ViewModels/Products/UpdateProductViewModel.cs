using MyChushka.WebApp.Models.Enums;

namespace MyChushka.WebApp.ViewModels.Products
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }
    }
}