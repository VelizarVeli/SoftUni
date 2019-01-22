using System;
using System.Linq;
using MusakaWebApp.Models;
using MusakaWebApp.ViewModels.Home;
using MusakaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MusakaWebApp.Controllers
{
    public class ProductsController : BaseController
    {

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(CreateProductInputModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Picture = model.Picture,
                Price = model.Price,
                Barcode = model.Barcode,
            };

            this.Db.Products.Add(product);
            this.Db.SaveChanges();

            return this.Redirect("/Products/All");
        }


        [Authorize]
        public IHttpResponse All()
        {
            var products = this.Db.Products.Select(x =>
                new ProductsViewModel()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Barcode = x.Barcode,
                    Picture = x.Picture
                }).ToList();

            var model = new AllProductsViewModel() { Products = products };
            return this.View(model);
        }
    }
}
