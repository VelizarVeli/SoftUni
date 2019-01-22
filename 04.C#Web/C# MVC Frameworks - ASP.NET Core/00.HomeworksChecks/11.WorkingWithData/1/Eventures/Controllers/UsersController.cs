using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Services.Contracts;
using Eventures.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class UsersController:Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return this.View(model);

            var result = this.usersService.Register(model.Username, model.Email, model.Password, model.ConfirmPassword,
                model.FirstName, model.LastName, model.UniqueCitizenNumber).Result;

            if (!result) return this.View();

            return this.RedirectToAction(nameof(Login));
        }
        
        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid) return this.View(model);

            var result = this.usersService.Login(model.Username, model.Password, model.RememberMe);

            if (!result) return this.View();

            return this.Redirect("/");
        }

        public IActionResult Login() => this.View();

        public IActionResult Logout()
        {
            this.usersService.Logout();
            return this.Redirect("/");
        }
    }
}
