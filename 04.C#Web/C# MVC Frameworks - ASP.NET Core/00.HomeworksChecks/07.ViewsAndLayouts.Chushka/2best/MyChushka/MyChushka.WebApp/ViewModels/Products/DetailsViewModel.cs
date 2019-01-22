using MyChushka.WebApp.Models.Enums;

namespace MyChushka.WebApp.ViewModels.Products
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                if (this.Description.Length > 50)
                {
                    var result = this.Description.Substring(0, 50);

                    return result + "...";
                }

                return this.Description;
            }
        }
    }
}