using System.Linq;
using CHUSHKA.Models;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Web.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<ChushkaUser> signIn;

        public AccountController(SignInManager<ChushkaUser> signIn, RoleManager<IdentityRole> roleManager)
        {
            this.signIn = signIn;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = this.signIn.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            var user = new ChushkaUser
            {
                Email = viewModel.Email,
                FullName = viewModel.FullName,
                UserName = viewModel.Username
            };

            var result = this.signIn.UserManager.CreateAsync(user, viewModel.Password).Result;

            if (this.signIn.UserManager.Users.Count() == 1)
            {
               var roleResult = this.signIn.UserManager.AddToRoleAsync(user, "Administrator").Result;
                if (roleResult.Errors.Any())
                {
                    return this.View();
                }
            }

            if (result.Succeeded)
            {
                this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
    }
}
