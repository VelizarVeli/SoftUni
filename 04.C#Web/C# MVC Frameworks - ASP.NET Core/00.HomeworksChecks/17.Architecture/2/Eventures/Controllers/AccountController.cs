namespace Eventures.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Eventures.Models;
    using Eventures.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AccountController : Controller
    {
        private SignInManager<EventuresUser> signIn;
        private IMapper mapper;

        public AccountController(SignInManager<EventuresUser> signIn, IMapper mapper)
        {
            this.mapper = mapper;
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
            this.signIn.SignInAsync(user, model.RememberMe).Wait();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        public IActionResult Logout()
        {
            this.signIn.SignOutAsync();

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {

            var user = mapper.Map<EventuresUser>(registerViewModel);
            //var user = new EventuresUser
            //{
            //    Email = registerViewModel.Email,
            //    UserName = registerViewModel.Username
            //};

            var result = this.signIn.UserManager.CreateAsync(user, registerViewModel.Password).Result;

            if (result.Succeeded)
            {
                this.signIn.SignInAsync(user, false);
                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
