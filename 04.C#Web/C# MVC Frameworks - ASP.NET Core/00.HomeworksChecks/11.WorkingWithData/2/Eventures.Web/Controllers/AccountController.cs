using System.Linq;
using Eventures.Models;
using Eventures.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class AccountController : BaseController
    {
        private SignInManager<EventuresUser> signIn;

        public AccountController(SignInManager<EventuresUser> signIn)
        {
            this.signIn = signIn;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = this.signIn.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            this.signIn.SignInAsync(user, true).Wait();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var user = new EventuresUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UCN = model.UCN,         
                UserName = model.Username
            };
            var result = this.signIn.UserManager.CreateAsync(user, model.Password).Result;

            if (this.signIn.UserManager.Users.Count() == 1)
            {
                var roleResult = this.signIn.UserManager.AddToRoleAsync(user, "Admin").Result;
                if (roleResult.Errors.Any())
                {
                    return this.View();
                }
            }

            if (result.Succeeded)
            {

                this.signIn.SignInAsync(user, false).Wait();
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }
    }
}