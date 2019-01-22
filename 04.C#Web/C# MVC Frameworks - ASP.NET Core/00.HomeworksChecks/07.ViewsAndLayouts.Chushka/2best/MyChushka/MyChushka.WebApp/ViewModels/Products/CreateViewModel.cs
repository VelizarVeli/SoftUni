using System.ComponentModel.DataAnnotations;

namespace MyChushka.WebApp.ViewModels.Products
{
    public class CreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public int Type { get; set; }
    }
}