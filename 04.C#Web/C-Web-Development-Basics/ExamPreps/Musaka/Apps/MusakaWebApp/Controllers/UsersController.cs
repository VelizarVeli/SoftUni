using System;
using System.Linq;
using MusakaWebApp.Models;
using MusakaWebApp.ViewModels.Users;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Services;

namespace MusakaWebApp.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IHashService hashService;

        public UsersController(IHashService hashService)
        {
            this.hashService = hashService;
        }

        [Authorize]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        public IHttpResponse Login()
        {
            if (this.User.IsLoggedIn)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(DoLoginInputModel model)
        {
            var hashedPassword = this.hashService.Hash(model.Password);

            var user = this.Db.Users.FirstOrDefault(x =>
                x.Username == model.Username.Trim() &&
                x.Password == hashedPassword);

            if (user == null)
            {
                return this.BadRequestErrorWithView("Invalid username or password.");
            }

            var mvcUser = new MvcUserInfo
            {
                Username = user.Username,
                Role = user.Role.ToString()
            };
            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

            var cookie = new HttpCookie(".auth-cakes", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        public IHttpResponse Register()
        {
            if (this.User.IsLoggedIn)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [Authorize]
        public IHttpResponse Index()
        {
            var profileProducts = this.Db.Receipts.Where(u => u.Cashier.Username == this.User.Username).Select(x =>
                new ProfileViewModel()
                {
                    Id = x.Id,
                    Total = x.Orders.Select(a => a.Product.Price).Sum(),
                    IssuedOn = x.IssuedOn.ToString("dd/MM/yyyy"),
                    Cashier = x.Cashier.Username,
                }).ToList();

            var model = new ProfileAllProductsViewModel() { Products = profileProducts };
            return this.View(model);
        }

        [HttpPost]
        public IHttpResponse Register(DoRegisterInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Trim().Length < 4)
            {
                return this.BadRequestErrorWithView("Please provide valid username with length of 4 or more characters.");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || model.Email.Trim().Length < 4)
            {
                return this.BadRequestErrorWithView("Please provide valid email with length of 4 or more characters.");
            }

            if (this.Db.Users.Any(x => x.Username == model.Username.Trim()))
            {
                return this.BadRequestErrorWithView("User with the same name already exists.");
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6)
            {
                return this.BadRequestErrorWithView("Please provide password of length 6 or more.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.BadRequestErrorWithView("Passwords do not match.");
            }

            var hashedPassword = this.hashService.Hash(model.Password);

            var role = UserRole.User;
            if (!this.Db.Users.Any())
            {
                role = UserRole.Admin;
            }

            var user = new User
            {
                Username = model.Username.Trim(),
                Email = model.Email.Trim(),
                Password = hashedPassword,
                Role = role,
            };
            this.Db.Users.Add(user);

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.BadRequestErrorWithView(e.Message);
            }

            return this.Redirect("/Users/Login");
        }
    }
}
