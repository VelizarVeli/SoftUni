using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventures.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService userService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UsersController(IUsersService userService, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.userService = userService;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var result = this.userService.Register(model.Username,
                model.Password,
                model.ConfirmPassword,
                model.Email,
                model.FirstName,
                model.LastName,
                model.Ucn);

            if (!result.Result)
            {
                return this.View(model);
            }

            return this.RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var result = this.userService.Login(model.Username, model.Password);

            if (!result.Result)
            {
                return this.View();
            }
             
            return this.Redirect("/");
        }
        
        public IActionResult Lockout()
        {
            return View();
        }

        //[Route("/Users/Logout")]
        public async Task<IActionResult> Logout()
        {
            await this._signInManager.SignOutAsync();

            return this.RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }

}
