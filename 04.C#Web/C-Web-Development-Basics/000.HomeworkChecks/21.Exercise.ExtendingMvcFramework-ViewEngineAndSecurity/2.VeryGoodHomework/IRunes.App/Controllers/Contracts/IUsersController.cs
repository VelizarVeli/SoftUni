using IRunes.App.ViewModels;
using SIS.Framework.ActionResults.Contracts;

namespace IRunes.App.Controllers.Contracts
{
    public interface IUsersController
    {
	IActionResult Login();
	IActionResult Login(LoginViewModel model);
	IActionResult Logout();
	IActionResult Register();
	IActionResult Register(RegisterViewModel model);
    }
}
