namespace WebServer.IRunesApplication.Services.Contracts
{
    using System.Collections.Generic;
    using ViewModels.Product;

    public interface IProductService
    {
        void Create(string name, string imageUrl);

        IEnumerable<ProductListingViewModel> All(string searchTerm = null);

        ProductDetailsViewModel Find(int id);        
    }
}
