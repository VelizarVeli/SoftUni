using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyChushka.WebApp.Constants;
using MyChushka.WebApp.Data;
using MyChushka.WebApp.Models;
using MyChushka.WebApp.Models.Enums;
using MyChushka.WebApp.ViewModels.Products;

namespace MyChushka.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProductsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var model = this.db.Products
                .Where(p => p.Id == id)
                .Select(p => new DetailsViewModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price,
                    Type = p.Type
                })
                .FirstOrDefault();

            if (model == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(model);
        }

        [Authorize]
        public IActionResult Order(int id)
        {
            return null;
        }

        [Authorize(Roles = MyConst.AdminRole)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = MyConst.AdminRole)]
        public IActionResult Create(CreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var product = new Product
                {
                    Type = (ProductType) model.Type,
                    Description = model.Description,
                    Price = model.Price,
                    Name = model.Name,
                };

                this.db.Products.Add(product);
                this.db.SaveChanges();

                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Create", "Products");
        }

        [Authorize(Roles = MyConst.AdminRole)]
        public IActionResult Edit(int id)
        {
            var model = this.db.Products
                .Where(p => p.Id == id)
                .Select(p => new UpdateProductViewModel
                {
                    Id = p.Id,
                    Type = (int)p.Type,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price
                })
                .FirstOrDefault();

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = MyConst.AdminRole)]
        public IActionResult Edit(UpdateProductViewModel model)
        {
            var product = this.db.Products
                .FirstOrDefault(p => p.Id == model.Id);

            product.Description = model.Description;
            product.Name = model.Name;
            product.Price = model.Price;
            product.Type = (ProductType)model.Type;

            this.db.SaveChanges();

            return this.Redirect($"/Products/Details/{model.Id}");
        }


        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var model = this.db.Products
                .Where(p => p.Id == id)
                .Select(p => new UpdateProductViewModel
                {
                    Id = p.Id,
                    Type = (int)p.Type,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price
                })
                .FirstOrDefault();

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = MyConst.AdminRole)]
        public IActionResult Delete(int id, string name)
        {
            var product = this.db.Products
                .FirstOrDefault(p => p.Id == id);

            this.db.Products.Remove(product);
            this.db.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }
    }
}