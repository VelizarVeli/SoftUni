namespace Eventures.WebApp.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

    public class UsersController : BaseController
    {
        private SignInManager<EventureUser> SignInManager { get; }

        public UsersController(SignInManager<EventureUser> signInManager, ApplicationDbContext context)
            : base(context)
        {
            this.SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.SignInManager.PasswordSignInAsync(model.Username,
                model.Password, true, false);

            if (result == SignInResult.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            this.ViewData["Error"] = "No such user";
            return this.View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = new EventureUser
            {
                UserName = model.Username,
                FirstName = model.Firstname,
                Email = model.Email,
                LastName = model.Email,
                UniqueCitizenNumber = model.UniqueCitizenNumber
            };

            await this.SignInManager.UserManager.CreateAsync(user, model.Password);

            var result = await this.SignInManager.PasswordSignInAsync(model.Username,
                model.Password, true, false);

            if (result == SignInResult.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await this.SignInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgottenPassword()
        {
            return NotFound();
        }
    }
}