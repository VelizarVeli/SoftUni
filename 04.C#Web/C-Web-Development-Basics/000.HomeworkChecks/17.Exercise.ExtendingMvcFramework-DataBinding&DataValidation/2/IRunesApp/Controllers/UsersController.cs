namespace IRunesApp.Controllers
{
    using Common;
    using Models;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MVC.Framework.Attributes;
    using SIS.MVC.Framework.Services.Contracts;
    using System;
    using System.Linq;
    using ViewModels.Users;

    public class UsersController : BaseController
    {
        private readonly IHashService hashService;

        public UsersController(IHashService hashService)
        {
            this.hashService = hashService;
        }

        [HttpGet("/users/login")]
        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost("/users/login")]
        public IHttpResponse DoLogin(DoLoginInputModel model)
        {
            var hashedPassword = this.hashService.Hash(model.Password);
            var user = this.Db.Users.FirstOrDefault(u => u.Username == model.Username && u.HashedPassword == hashedPassword);
            if (user == null)
            {
                return this.RedirectResult("/login");
            }

            this.SignInUser(model.Username);

            return this.RedirectResult("/");
        }

        [HttpGet("/users/register")]
        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/users/register")]
        public IHttpResponse DoRegister(DoRegisterInputModel model)
        {
            // Validate
            this.ValidateRegisterUsername(model.Username.Trim());
            this.ValidateRegisterPassword(model.Password, model.ConfirmPassword);

            // Generate password hash
            var hashedPassword = this.hashService.Hash(model.Password);

            // Create user
            this.CreateAndSaveUser(model.Username.Trim(), model.Email, hashedPassword);

            this.SignInUser(model.Username.Trim());

            return this.RedirectResult("/"); ;
        }

        [HttpGet("/users/logout")]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(Constants.HttpCookieKey))
            {
                return this.RedirectResult("/");
            }

            var cookie = this.Request.Cookies.GetCookie(Constants.HttpCookieKey);
            cookie.Delete();
            this.Response.Cookies.Add(cookie);

            return this.RedirectResult("/"); ;
        }

        private void CreateAndSaveUser(string userName, string email, string hashedPassword)
        {
            var user = new User()
            {
                Username = userName,
                Email = email,
                HashedPassword = hashedPassword
            };

            try
            {
                this.Db.Users.Add(user);
                this.Db.SaveChanges();
            }
            catch (Exception exception)
            {
                this.ServerError(exception.Message);
            }
        }

        private void ValidateRegisterPassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                this.BadRequestError(Messages.InvalidPassword);
            }

            if (password != confirmPassword)
            {
                this.BadRequestError(Messages.PasswordsDontMatch);
            }
        }

        private void ValidateRegisterUsername(string userName)
        {
            if (string.IsNullOrEmpty(userName) || userName.Length < 4)
            {
                this.BadRequestError(Messages.InvalidUsername);
            }

            if (this.Db.Users.Any(u => u.Username == userName))
            {
                this.BadRequestError(Messages.UserExists);
            }
        }
    }
}