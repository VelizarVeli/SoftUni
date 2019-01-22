using IRunesWebApp.Services.Contracts;
using IRunesWebApp.ViewModels;
using SIS.Framework.ActionsResults.Base;
using SIS.Framework.Attributes.Action;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Controllers;
using SIS.Framework.Security;

namespace IRunesWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid.HasValue || !ModelState.IsValid.Value)
            {
                return this.RedirectToAction("/users/login");
            }

            var userExists = this.usersService.ExistsByUsernameAndPassword(model.Username, model.Password);

            if (!userExists)
            {
                return this.RedirectToAction("/users/login");
            }

            this.SignIn(new IdentityUser { Username = model.Username, Password = model.Password });
            return this.RedirectToAction("/home/index");
        }

        [Authorize]
        public IActionResult Register() => this.View();
    }
}
