using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyChushka.WebApp.Constants;
using MyChushka.WebApp.Data;
using MyChushka.WebApp.Models;
using MyChushka.WebApp.ViewModels.Users;

namespace MyChushka.WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly ApplicationDbContext db;

        public UsersController(
            SignInManager<AppUser> signInManager, 
            UserManager<AppUser> userManager, 
            ApplicationDbContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.db = db;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = this.signInManager
                    .PasswordSignInAsync(model.Username, model.Password, true, true)
                    .GetAwaiter()
                    .GetResult();

                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index", "Home");
                }
            }

            return this.RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email ,
                    FullName = model.FullName
                };

                var roleName = "User";
                if (!this.db.AppUsers.Any())
                {
                    roleName = MyConst.AdminRole;
                }

                var dbRole = this.db.Roles.FirstOrDefault(r => r.Name == roleName);
                if (dbRole == null)
                {
                    dbRole = new IdentityRole(roleName);
                    this.db.Roles.Add(dbRole);
                    this.db.SaveChanges();
                }

                var result = this.userManager
                    .CreateAsync(user, model.Password)
                    .GetAwaiter()
                    .GetResult();

                if (result.Succeeded)
                {
                    this.db
                        .UserRoles
                        .Add(new IdentityUserRole<string> { RoleId = dbRole.Id, UserId = user.Id });
                    this.db.SaveChanges();

                    this.signInManager.SignInAsync(user, isPersistent: false)
                        .GetAwaiter()
                        .GetResult();

                    return this.RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return this.RedirectToAction("Register", "Users");
        }

        public IActionResult Logout()
        {
            this.signInManager.SignOutAsync()
                .GetAwaiter()
                .GetResult();

            return this.RedirectToAction("Index", "Home");
        }
    }
}