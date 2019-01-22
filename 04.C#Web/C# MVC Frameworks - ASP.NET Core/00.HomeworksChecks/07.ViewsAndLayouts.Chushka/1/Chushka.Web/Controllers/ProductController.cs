using System;
using System.Collections.Generic;
using System.Linq;
using Chushka.Models;
using Chushka.Web.Data;
using Chushka.Web.Models;
using Chushka.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Chushka.Web.Controllers
{
    public class ProductController : Controller
    {
        private ChushkaDbContext dbContext;
        private SignInManager<ChushkaUser> signInManager;

        public ProductController(ChushkaDbContext dbContext, SignInManager<ChushkaUser> signInManager)
        {
            this.dbContext = dbContext;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)
        {
            var product = dbContext.Products.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var productViewModel = new ProductViewModel
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Type = product.Type.ToString()
            };

            return View(productViewModel);
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.Administrator)]
        public IActionResult Edit(int? id)
        {
            var product = dbContext.Products.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Type = product.Type.ToString(),
                Price = product.Price
            };

            return View(productViewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            int id = productViewModel.Id;
            string name = productViewModel.Name;
            string description = productViewModel.Description;
            ProductType type = Enum.Parse<ProductType>(productViewModel.Type);
            decimal price = productViewModel.Price;

            using (dbContext)
            {
                Product product = dbContext.Products.Find(id);
                product.Name = name;
                product.Description = description;
                product.Type = type;
                product.Price = price;

                dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.Administrator)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (this.ModelState.IsValid)
            {
                using (this.dbContext)
                {
                    Product product = new Product()
                    {
                        Name = productViewModel.Name,
                        Description = productViewModel.Description,
                        Price = productViewModel.Price,
                        Type = Enum.Parse<ProductType>(productViewModel.Type)
                    };

                    this.dbContext.Products.Add(product);

                    this.dbContext.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.Administrator)]
        public IActionResult Delete(int? id)
        {
            var product = dbContext.Products.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Type = product.Type.ToString(),
                Price = product.Price
            };

            return View(productViewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public IActionResult Delete(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            using (dbContext)
            {
                dbContext.Products.Remove(dbContext.Products.Find(productViewModel.Id));

                dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Order(int id)
        {
            Product product = dbContext.Products.Find(id);

            var userId = this.signInManager.UserManager.GetUserId(this.User);

            using (dbContext)
            {
                var user = dbContext.Users.Find(userId);

                dbContext.Orders.Add(new Order()
                {
                    Product = product,
                    Client = user,
                    OrderedOn = DateTime.Now
                });

                dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = RoleNames.Administrator)]
        public IActionResult All()
        {
            List<OrderViewModel> query;

            using (dbContext)
            {
                var orders = dbContext.Orders;
                var products = dbContext.Products;

                query = orders.GroupJoin(products,
                    order => order.ProductId,
                    product => product.Id,
                    (order, orderGroup) => new OrderViewModel()
                    {
                        OrderId = order.Id,
                        OrderedOn = $"{order.OrderedOn.Hour}:{order.OrderedOn.Minute} {order.OrderedOn.Day}/{order.OrderedOn.Month}/{order.OrderedOn.Year}",
                        Product = orderGroup.FirstOrDefault(p => p.Id == order.ProductId).Name,
                        Customer = this.signInManager.UserManager.GetUserName(User)
                    }).ToList();
            }

            return View(query);
        }
    }
}