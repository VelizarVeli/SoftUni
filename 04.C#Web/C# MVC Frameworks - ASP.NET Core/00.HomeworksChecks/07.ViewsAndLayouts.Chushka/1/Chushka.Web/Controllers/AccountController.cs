using Chushka.Models;
using Chushka.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Chushka.Web.Utilities;

namespace Chushka.Web.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<ChushkaUser> singInManager;

        public AccountController(SignInManager<ChushkaUser> singInManager)
        {
            this.singInManager = singInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogInViewModel logInViewModel)
        {
            var user = this.singInManager.UserManager.Users.FirstOrDefault(u => u.UserName == logInViewModel.Username);
            this.singInManager.SignInAsync(user, true).Wait();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await this.singInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            var user = new ChushkaUser()
            {
                Email = viewModel.Email,
                FullName = viewModel.FullName,
                UserName = viewModel.Username
            };

            var result = this.singInManager.UserManager.CreateAsync(user, viewModel.Password).Result;

            string roleToAdd = RoleNames.User;
            
            if (this.singInManager.UserManager.Users.Count() == 1)
            {
                roleToAdd = RoleNames.Administrator;
            }

            var roleResult = this.singInManager.UserManager.AddToRoleAsync(user, roleToAdd).Result;

            if (result.Succeeded)
            {
                this.singInManager.SignInAsync(user, true).Wait();

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
    }
}