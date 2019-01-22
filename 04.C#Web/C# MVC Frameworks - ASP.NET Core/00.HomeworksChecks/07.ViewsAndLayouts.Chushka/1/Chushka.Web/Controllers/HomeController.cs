using Chushka.Models;
using Chushka.Web.Data;
using Chushka.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Chushka.Web.Controllers
{
    public class HomeController : Controller
    {
        private ChushkaDbContext dbContext;

        public HomeController(ChushkaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var viewModels = new List<ProductViewModel>();

            if (this.User != null)
            {
                using (dbContext)
                {
                    foreach (Product product in dbContext.Products)
                    {
                        viewModels.Add
                        (
                            new ProductViewModel()
                            {
                                Id = product.Id,
                                Name = product.Name,
                                Description = product.Description,
                                Price = product.Price,
                                Type = product.Type.ToString()
                            }
                        );
                    }
                }               
            }

            return View(viewModels);
        }
    }
}
