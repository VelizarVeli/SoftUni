using IRunes.Extensions;
using IRunes.Models;
using IRunes.Services;
using IRunes.ViewModels.User;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes;
using SIS.Framework.Attributes.Action;
using SIS.Framework.Security;
using SIS.HTTP.Cookies;
using System.Linq;

namespace IRunes.Controllers
{
    public class UserController : BaseController
    {
        private HashService hashService;

        public UserController()
        {
            this.hashService = new HashService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User != null)
            {
                this.Model["username"] = this.User;
                return this.RedirectToAction("/");
            }

            return this.View();
        }   

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            string username = model.Username.UrlDecode();
            string password = model.Password.UrlDecode();

            var hashedPassword = this.hashService.Hash(password);

            var user = this.context.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

            if (user == null)
            {
                return this.View();
            }

            this.IsUserAuthenticated = true;

            this.Request.Session.AddParameter("username", username);

            this.Model["username"] = username;

            var cookieContent = this.UserCookieService.GetUserCookie(user.Username);
            this.Cookies.Add(new HttpCookie("_auth", cookieContent));

            this.SignIn(new IdentityUser { Username = username, Password = password });

            return this.RedirectToAction("/Home/Index");
        }

        [Authorize]
        public IActionResult Authorized()
        {
            this.Model["username"] = this.Identity.Username;
            return this.View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            string username = model.Username.UrlDecode();
            string password = model.Password.UrlDecode();
            string confirmPassword = model.ConfirmPassword.UrlDecode();
            string email = model.Email.UrlDecode();

            if (this.context.Users.Any(u => u.Username == username))
            {
                return this.View();
            }

            if (password != confirmPassword)
            {
                return this.View();
            }

            if (username.Contains("@"))
            {
                return this.View();
            }

            if (!email.Contains("@"))
            {
                return this.View();
            }

            string hashedPassword = this.hashService.Hash(password);

            User user = new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return this.RedirectToAction("/User/Login");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (this.User == null)
            {
                return this.RedirectToAction("/");
            }
            
            var cookie = this.Request.Cookies.GetCookie("_auth");

            cookie.Delete();

            this.Cookies.Add(cookie);

            return RedirectToAction("/");
        }
    }
}