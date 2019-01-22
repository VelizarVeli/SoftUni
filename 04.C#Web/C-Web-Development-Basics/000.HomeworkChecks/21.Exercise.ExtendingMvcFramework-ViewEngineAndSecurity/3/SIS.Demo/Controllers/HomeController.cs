using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Controllers;

namespace SIS.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
