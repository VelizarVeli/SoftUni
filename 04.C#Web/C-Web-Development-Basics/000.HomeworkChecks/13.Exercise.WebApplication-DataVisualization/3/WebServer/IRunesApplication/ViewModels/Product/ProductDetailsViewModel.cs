namespace WebServer.IRunesApplication.ViewModels.Product
{
    using System.Collections.Generic;

    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public List<TrackViewModel> Tracks { get; set; } = new List<TrackViewModel>();
    }
}
