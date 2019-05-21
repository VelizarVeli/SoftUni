using Microsoft.AspNetCore.Mvc;

namespace Panda.Web.Controllers
{
    public class ReceiptController : Controller
    {
        public IActionResult Index()
        {
            return PartialView("Index");
        }
    }
}