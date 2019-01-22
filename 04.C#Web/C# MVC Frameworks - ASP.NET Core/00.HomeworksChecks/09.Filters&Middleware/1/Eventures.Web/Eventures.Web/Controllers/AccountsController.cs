namespace Eventures.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using ViewModels.Accounts;

    public class AccountsController : Controller
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var result = this.accountService.Register(registerViewModel.Username, registerViewModel.Email, registerViewModel.Password, registerViewModel.ConfirmPassword, registerViewModel.FirstName, registerViewModel.LastName, registerViewModel.UniqueCitizenNumber)
                .GetAwaiter()
                .GetResult();

            if (!result)
            {
                return this.View();
            }

            return this.RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(loginViewModel);
            }

            var result = this.accountService.Login(loginViewModel.Username, loginViewModel.Password)
                .GetAwaiter()
                .GetResult();

            if (!result)
            {
                return this.View();
            }

            return this.Redirect("/");
        }

        public IActionResult Logout()
        {
            this.accountService.Logout(); ;
            return this.Redirect("/");
        }
    }
}