using Microsoft.AspNetCore.Mvc;

namespace Panda.Web.Controllers
{
    public class ReceiptsController : Controller
    {
        public IActionResult Index()
        {
            return PartialView("Index");
        }
    }
}