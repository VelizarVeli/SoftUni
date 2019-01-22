using Eventures.Common;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.Filters;
using Eventures.Web.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventures.Web.Controllers
{
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    public class AccountController : Controller
    {
        private SignInManager<EventuresUser> signInManager;

        private IUsersService usersService;

        public AccountController(SignInManager<EventuresUser> signInManager, IUsersService usersService)
        {
            this.signInManager = signInManager;
            this.usersService = usersService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.usersService.CreateUser(model, model.Password);

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return this.View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.usersService.LoginUser(model.Username, model.Password, model.RememberMe, false);

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, ErrorMessages.InvalidLogin);

            return this.View();
        }

        public async Task<IActionResult> ExternalLogin()
        {
            var info = await this.signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var result = await this.usersService.ExternalLoginUser(info);

            if (result)
            {
                return this.RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, ErrorMessages.NotUniqueEmail);
            return this.RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = "/Account/ExternalLogin";
            var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
