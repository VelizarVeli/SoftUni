namespace SIS.Demo.Controllers
{
    using Framework.ActionResults;
    using Framework.ActionResults.Contracts;
    using Framework.Attributes;
    using Framework.Controllers;
    using ViewModels;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
            => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {

            string username = lvm.Username;
            string password = lvm.Password;

            return new RedirectResult("/home/welcome");
        }

        [HttpGet]
        public IActionResult Welcome()
            => this.View();
    }
}
