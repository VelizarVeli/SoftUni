using IRunes.Models.ViewModels.Users;
using IRunes.Services.Contracts;
using SIS.Framework.ActionResults.Base;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Controllers;
using SIS.HTTP.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IHashService hashService;

        private readonly IUserService userService;

        public UsersController(IUserService userService, IHashService hashService)
        {
            this.userService = userService;
            this.hashService = hashService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/");
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/");
            }

            LoginViewModel user = this.userService.GetUser(model.Login);

            var base64Hash = user.Password;

            if (!this.hashService.IsPasswordValid(model.Password, base64Hash))
            {
                return this.View();
            }

            this.Request.Session.AddParameter("username", user.Login);
            return this.RedirectToAction("/");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.View();
            }

            if (this.userService.CheckIfUserExists(model.Username))
            {
                return this.View();
            }

            if (this.userService.CheckIfEmailIsTaken(model.Email))
            {
                return this.View();
            }

            model.Password = this.hashService.HashPassword(model.Password, this.hashService.GenerateSalt());

            this.userService.CreateUser(model);

            this.Request.Session.AddParameter("username", model.Username);
            return this.RedirectToAction("/");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (this.Request.IsLoggedIn())
            {
                this.Request.Session.RemoveParameter("username");
            }

            return this.RedirectToAction("/");
        }
    }
}
