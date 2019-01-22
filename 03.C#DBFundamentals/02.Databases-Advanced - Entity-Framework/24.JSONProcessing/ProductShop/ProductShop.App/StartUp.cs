using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace ProductShop.App
{
    using AutoMapper;

    using Data;
    using Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            var context = new ProductShopContext();

            var users = context.Users
                .Where(x => x.ProductsSold.Count >= 1 && x.ProductsSold.Any(s => s.Buyer != null))
                .OrderBy(l => l.LastName)
                .ThenBy(l => l.FirstName)
                .Select(s => new
                {
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    soldProducts = s.ProductsSold.Where(x => x.Buyer != null)
                    .Select(v => new
                    {
                        name = v.Name,
                        price = v.Price,
                        BFName = v.Buyer.FirstName,
                        BfFamilyName = v.Buyer.LastName
                    }).ToArray()
                }).ToArray();

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(s => new
                {
                    name = s.Name,
                    price = s.Price,
                    seller = s.Seller.FirstName + " " + s.Seller.LastName ?? s.Seller.LastName
                })
                .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText("Json/products-in-range.json", jsonProducts);

            //var categoryProducts = new List<CategoryProduct>();

            //for (int productId = 1; productId <= 200; productId++)
            //{
            //    var categoryId = new Random().Next(1, 12);

            //    var categoryProduct = new CategoryProduct
            //    {
            //        CategoryId = categoryId,
            //        ProductId = productId
            //    };

            //    categoryProducts.Add(categoryProduct);
            //}

            //context.CategoryProducts.AddRange(categoryProducts);
            //context.SaveChanges();



            //var jsonString = File.ReadAllText("Json/products.json");

            //var deserializedUsers = JsonConvert.DeserializeObject<Product[]>(jsonString);

            //List<Product> products = new List<Product>();

            //foreach (var product in deserializedUsers)
            //{
            //    if (!IsValid(product))
            //    {
            //        continue;
            //    }

            //    var sellerId = new Random().Next(1, 35);
            //    var buyerId = new Random().Next(35, 57);

            //    var random = new Random().Next(1, 3);

            //    product.SellerId = sellerId;
            //    product.BuyerId = buyerId;

            //    if (random == 3)
            //    {
            //        product.BuyerId = null;
            //    }

            //    products.Add(product);
            //}

            //context.Products.AddRange(products);
            //context.SaveChanges();
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
