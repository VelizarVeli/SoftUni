namespace EventWebApp.Controllers
{
    using System.Security.Claims;
    using Common;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Models;
    using Models.Account;
    using Services.Contracts;

    public class AccountController : Controller
    {

        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return this.View();
        }

        // POST: Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var result = this.accountService.Login(model);
            if (result is PageResult)
            {
                result = this.View("_Error", new ErrorViewModel { Description = "Invalid login attempt" });
            }

            return result;
        }

        //POST:Account/ExternalLogin
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = "/Account/ExternalLogin";
            AuthenticationProperties properties = this.accountService.ConfigureExternalLoginProperties(provider,redirectUrl);
           
            return  new ChallengeResult(provider, properties);
        }


        public IActionResult ExternalLogin()
        {
            this.accountService.CreateUserExternal();
            return this.RedirectToAction("Index", "Home");
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return this.View();
        }

        // POST: Account/Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var result = this.accountService.Register(model);
            if (result is PageResult)
            {
                result = this.View("_Error", new ErrorViewModel { Description = "Invalid registration attempt" });
            }

            return result;
        }

        public IActionResult Logout()
        {
            return this.accountService.Logout();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            var users = new AdminPanelUsersListViewModel{Users = this.accountService.AdminPanelUsers()};
            return this.View(users);
        }
       
        [Authorize(Roles = "Admin")]
        public IActionResult Demote(string id)
        {
            this.accountService.Demote(id);
            return this.RedirectToAction("AdminPanel");
        }
     
        [Authorize(Roles = "Admin")]
        public IActionResult Promote(string id)
        {
            this.accountService.Promote(id);
            return this.RedirectToAction("AdminPanel");
        }
    }
}