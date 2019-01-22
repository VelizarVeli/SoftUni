using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyChushka.WebApp.Data;
using MyChushka.WebApp.ViewModels;
using MyChushka.WebApp.ViewModels.Home;

namespace MyChushka.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.View("AnonymousIndex");
            }

            var model = this.db.Products
                .Select(p => new IndexNodeViewModel
                {
                    Description = p.Description,
                    Price = p.Price,
                    Name = p.Name,
                    Id = p.Id
                })
                .ToList();

            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
