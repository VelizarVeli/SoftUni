using Microsoft.AspNetCore.Mvc;
using Panda1.Data;

namespace Panda1.Controllers
{
    public class HomeController : Controller
    {
        private PandaDbContext context;

        public HomeController(PandaDbContext ctx) => context = ctx;

        public IActionResult Index()
        {
            return this.View();
        }
    }
}