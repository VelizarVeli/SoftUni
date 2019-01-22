namespace SIS.FrameworkDemo.Controllers
{
    using Framework.ActionResults.Contracts;
    using Framework.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}