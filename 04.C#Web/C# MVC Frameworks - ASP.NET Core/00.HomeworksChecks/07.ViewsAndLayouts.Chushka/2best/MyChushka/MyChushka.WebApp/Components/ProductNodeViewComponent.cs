using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyChushka.WebApp.Data;
using MyChushka.WebApp.ViewModels.Home;

namespace MyChushka.WebApp.Components
{
    //[ViewComponent(Name = "ProductNode")]
    public class ProductNodeViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public ProductNodeViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke(int id)
        {
            var model = this.db.Products
                .Where(p => p.Id == id)
                .Select(p => new IndexNodeViewModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price
                })
                .FirstOrDefault();

            return this.View(model);
        }
    }
}