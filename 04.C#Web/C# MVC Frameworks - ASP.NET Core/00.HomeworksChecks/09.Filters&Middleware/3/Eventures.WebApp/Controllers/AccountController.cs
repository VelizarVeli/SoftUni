namespace Eventures.WebApp.Controllers
{
	using System.Threading.Tasks;
	using EventuresModel;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Services.AccountServices.Contracts;
	using ViewModels.Account;

	public class AccountController : Controller
    {
	    public IAccountService AccountsService { get; set; }
	    private SignInManager<EventuresUser> SignInManager { get; }

	    public AccountController(IAccountService accountsService, SignInManager<EventuresUser> signInManager)
	    {
		    this.AccountsService = accountsService;
		    this.SignInManager = signInManager;
	    }

        public IActionResult Login()
        {
            return this.View();
        }

	    [HttpPost]
	    public async Task<IActionResult> Login(LoginViewModel model)
	    {
		    if (this.ModelState.IsValid)
		    {
			    var result = await this.SignInManager.PasswordSignInAsync(model.UserName,
				    model.Password, false, false);

			    if (result.Succeeded)
			    {
				    return this.RedirectToAction("Index", "Home");
			    }
		    }

		    return this.View();
	    }
	    public IActionResult Register()
	    {
		    return this.View();
	    }
	    [HttpPost]
	    public async Task<IActionResult> Register(RegisterViewModel model)
	    {
		    if (this.ModelState.IsValid)
		    {
			    var user = new EventuresUser()
			    {
				    UserName = model.UserName, 
				    Email = model.Email, 
				    FirstName = model.FirstName,
				    LastName = model.LastName,
					UniqueCitizenNumber = model.UniqueCitizenNumber,
			    };
			    var result = await this.SignInManager.UserManager.CreateAsync(user, model.Password);

			    if (result.Succeeded)
			    {
				    await this.SignInManager.SignInAsync(user, false);
				    return this.RedirectToAction("Index", "Home");
			    }
			    else
			    {
				    foreach (var error in result.Errors)
				    {
					    this.ModelState.AddModelError("", error.Description);
				    }
			    }
		    }
		    return this.View();
	    }
	    public IActionResult Logout()
	    {
		    var user = this.User;
		    this.AccountsService.LogoutUser();
		    return this.RedirectToAction("Index", "Home");
	    }
    }
}