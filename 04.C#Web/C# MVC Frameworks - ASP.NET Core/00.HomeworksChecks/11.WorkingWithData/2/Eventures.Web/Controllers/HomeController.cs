using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
