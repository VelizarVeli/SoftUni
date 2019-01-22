using System.Threading.Tasks;

namespace EventuresWebApp.Web.Controllers
{
    using AutoMapper;
    using System;
    using System.Linq;
    using Models;
    using ViewModels.Accounts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AccountsController : Controller
    {
        private readonly SignInManager<EventuresUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public AccountsController(
            SignInManager<EventuresUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
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
                return this.View(model);
            }

            var user = this.signInManager.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            try
            {
                this.signInManager.SignInAsync(user, model.RememberMe).Wait();
            }
            catch (Exception)
            {
                return this.View(model);
            }

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = this.mapper.Map<EventuresUser>(model);

            var result = this.signInManager.UserManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                return this.RedirectToAction("Login");
            }

            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.signInManager.SignOutAsync().Wait();
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Administration()
        {
            var users = this.signInManager
                .UserManager
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                })
                .ToList();

            foreach (var userViewModel in users)
            {
                var user = this.signInManager
                    .UserManager
                    .FindByIdAsync(userViewModel.Id)
                    .GetAwaiter()
                    .GetResult();

                userViewModel.IsAdmin = this.signInManager
                    .UserManager
                    .IsInRoleAsync(user, "Administrator")
                    .GetAwaiter()
                    .GetResult();
            }

            var administrationViewModel = new AdministrationViewModel
            {
                Users = users
            };

            return View(administrationViewModel);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Promote(string id)
        {
            var user = await this.signInManager.UserManager.FindByIdAsync(id);

            if (!await this.signInManager.UserManager.IsInRoleAsync(user, "Administrator"))
            {
                await this.signInManager.UserManager.AddToRoleAsync(user, "Administrator");
            }

            return this.RedirectToAction("Administration");
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Demote(string id)
        {
            var user = await this.signInManager.UserManager.FindByIdAsync(id);

            if (await this.signInManager.UserManager.IsInRoleAsync(user, "Administrator"))
            {
                await this.signInManager.UserManager.RemoveFromRoleAsync(user, "Administrator");
            }           

            return this.RedirectToAction("Administration");
        }
    }
}
