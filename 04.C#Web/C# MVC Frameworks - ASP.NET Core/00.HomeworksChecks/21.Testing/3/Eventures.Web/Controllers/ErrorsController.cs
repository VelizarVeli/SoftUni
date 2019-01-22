using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            return View("Error");
        }

        public IActionResult Error(string Id)
        {
            return View("Error404");
        }

    }
}
