using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes;

namespace IRunes.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (this.User != null)
            {
                this.Model["username"] = this.User;
            }

            return this.View();
        }
    }
}