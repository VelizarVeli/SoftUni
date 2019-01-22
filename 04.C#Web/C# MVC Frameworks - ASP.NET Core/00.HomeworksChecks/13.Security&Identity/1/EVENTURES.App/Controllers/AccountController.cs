using EVENTURES.App.ViewModels;
using EVENTURES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<EvUser> signIn;
        //private RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<EvUser> signIn)
        //RoleManager<IdentityRole> roleManager)
        {
            this.signIn = signIn;
            //this.roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = this.signIn.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            if (user == null || new PasswordHasher<EvUser>().VerifyHashedPassword(user, user.PasswordHash, model.Password)
                == PasswordVerificationResult.Failed)
            {
                // password is incorrect
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            await this.signIn.SignInAsync(user, model.RememberMe);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    return RedirectToAction("Register", "Account");
                }
                var user = new EvUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    PasswordHash = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UCN = model.UCN
                };
                var result = await this.signIn.UserManager.CreateAsync(user, model.Password);

                if (this.signIn.UserManager.Users.Count() == 1)
                {
                    var roleResult = await this.signIn.UserManager.AddToRoleAsync(user, "Administrator");
                    if (roleResult.Errors.Any())
                    {
                        return this.View();
                    }
                }

                if (result.Succeeded)
                {
                    await this.signIn.SignInAsync(user, false);
                    return this.RedirectToAction("Index", "Home");
                }
            }
            return this.View();
        }

        public async Task<IActionResult> Logout()
        {
            await this.signIn.SignOutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
