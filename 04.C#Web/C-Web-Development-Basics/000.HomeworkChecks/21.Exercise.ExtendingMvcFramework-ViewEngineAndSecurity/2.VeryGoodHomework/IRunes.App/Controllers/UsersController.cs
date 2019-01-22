using System.Threading.Tasks;
using IRunes.App.Common;
using IRunes.App.Controllers.Contracts;
using IRunes.App.ViewModels;
using IRunes.Services.Contracts;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes;
using SIS.Framework.Controllers;
using SIS.Framework.Security;
using SIS.Services.Contracts;

namespace IRunes.App.Controllers
{
    public class UsersController : Controller, IUsersController
    {
	private readonly IUserService UserService;
	private readonly IEncryptionService Encryptor;

	public UsersController(IUserService userService, IEncryptionService encryptionService)
	{
	    UserService = userService;
	    Encryptor = encryptionService;
	}

	[HttpGet]
	public IActionResult Login()
	{
	    if (Identity?.IsAuthenticated == true)
	    {
		return RedirectTo(Constants.HomeViewRoute);
	    }
	    else return View();
	}

	[HttpPost]
	public IActionResult Login(LoginViewModel model)
	{
	    Task<string> hashTask = Task.Run(() =>
	    {
		return Encryptor.HashPassword(model.Password);
	    });
	    string username = model.Username;
	    var user = UserService.GetUserByUsername(username)
		?? UserService.GetUserByEmail(username);
	    if (user == null)
	    {
		model.Data[Constants.ErrorKey] = Constants.InvalidCredentialsError;
		return View(model);
	    }
	    string hashedPassword = hashTask.Result;
	    if (user.Password != hashedPassword)
	    {
		model.Data[Constants.ErrorKey] = Constants.InvalidCredentialsError;
		return View(model);
	    }
	    var identity = new IdentityUser()
	    {
		Email = user.Email,
		Id = user.Id,
		IsAuthenticated = true,
		PasswordHash = hashedPassword,
		Username = user.Username
	    };
	    SignIn(identity);
	    return RedirectTo(Constants.HomeViewRoute);
	}

	[HttpGet]
	public IActionResult Logout()
	{
	    SignOut();
	    return RedirectTo(Constants.HomeViewRoute);
	}

	[HttpGet]
	public IActionResult Register()
	{
	    if (Identity?.IsAuthenticated == true)
	    {
		return RedirectTo(Constants.HomeViewRoute);
	    }
	    else return View();
	}

	[HttpPost]
	public IActionResult Register(RegisterViewModel model)
	{
	    Task<string> hashTask = Task.Run(() =>
	    {
		return Encryptor.HashPassword(model.Password);
	    });
	    string username = model.Username;
	    if (UserService.Exists(username))
	    {
		model.Data[Constants.ErrorKey] = string
		    .Format(Constants.UsernameTakenError, username);
		return View(model);
	    }
	    UserService.AddUser(username, model.FirstName,
		model.LastName, model.Email, hashTask.Result);
	    return RedirectTo(Constants.LoginViewRoute);
	}
    }
}
