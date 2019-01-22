namespace WebServer.IRunesApplication.Services
{
    using Data;
    using Data.Models;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Product;

    public class ProductService : IProductService
    {
        public void Create(string name, string url)
        {
            using (var db = new IRunesDbContext())
            {
                var album = new Album()
                {
                    Name = name,
                    Cover = url
                };

                db.Albums.Add(album);
                db.SaveChanges();
            }
        }

        public IEnumerable<ProductListingViewModel> All(string searchTerm = null)
        {
            using (var db = new IRunesDbContext())
            {
                var albums = db.Albums
                    .Select(a => new ProductListingViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name
                    })
                    .ToList();

                return albums;
            }
        }

        public ProductDetailsViewModel Find(int id)
        {
            using (var db = new IRunesDbContext())
            {
                var tracks = db.Tracks
                    .Where(t => t.AlbumId == id)
                    .Select(t => new TrackViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                    .ToList();

                var album = db.Albums
                    .Where(a => a.Id == id)
                    .Select(a => new ProductDetailsViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        ImageUrl = a.Cover,
                        Price = a.Price,
                        Tracks = tracks                        
                    })
                    .FirstOrDefault();

                return album;
            }
        }          
    }
}
