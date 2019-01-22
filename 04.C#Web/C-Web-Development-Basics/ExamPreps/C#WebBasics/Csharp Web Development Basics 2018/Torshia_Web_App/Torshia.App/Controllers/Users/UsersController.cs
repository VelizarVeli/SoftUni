namespace Torshia.App.Controllers.Users
{
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Torshia.App.Models;
    using Torshia.App.Models.Enums;
    using Torshia.App.ViewModels.Users;

    public class UsersController : BaseController
    {
        public IHttpResponse Register()
        {
            return this.View("Users/Register");
        }

        [HttpPost]
        public IHttpResponse Register(PostRegisterViewModel model)
        {
            Regex usernameAndPasswordRegex = new Regex(@"^\w+$");
            Regex emailRegex = new Regex(@"^[A-z]+\@[A-z]+\.[A-z]{1,4}$");

            string hashedPassword = this.hashService.Hash(model.Password);
            string hashedConfirmPassword = this.hashService.Hash(model.ConfirmPassword);

            model.Email = StringExtensions.UrlDecode(model.Email);

            if (emailRegex.Match(model.Email).Success == false ||
                usernameAndPasswordRegex.Match(model.Password).Success == false ||
                model.Password.Length < 3 ||
                model.Password.Length > 50 ||
               (usernameAndPasswordRegex.Match(model.Username).Success == false ||
               model.Username.Length < 3 ||
               model.Username.Length > 30))
            {
                return this.BadRequestErrorWithView("Invalid registration information format!");
            }
            if (this.DbContext.Users.Any(user => user.Email == model.Email))
            {
                return this.BadRequestErrorWithView("Email is already in use!");
            }
            if (hashedConfirmPassword == hashedPassword)
            {
                //Adding user to db 

                User user = new User()
                {
                    Username = model.Username,
                    Password = hashedPassword,
                    Email = model.Email
                };

                if (!this.DbContext.Users.Any())
                {
                    user.Role = Role.Admin;
                    model.Role = Role.Admin;
                }
                else
                {
                    user.Role = Role.User;
                    model.Role = Role.User;
                }

                using (this.DbContext)
                {
                    if (this.DbContext.Users.Any(u => u.Username == model.Username) == true)
                    {
                        return this.BadRequestErrorWithView("Username already exists!");
                    }

                    this.DbContext.Users.Add(user);
                    this.DbContext.SaveChanges();
                }

                ////Adding cookie
                var mvcUser = new MvcUserInfo { Username = user.Username, Role = user.Role.ToString() };
                var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);
                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, cookieContent);

                this.Request.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookie);
            }

            return this.Redirect("/");
        }
        
        public IHttpResponse Login()
        {
            return this.View("Users/Login");
        }

        [HttpPost]
        public IHttpResponse Login(PostRegisterViewModel model)
        {
            string hashedPassword = this.hashService.Hash(model.Password);
            
            if (!(this.DbContext.Users.Any(user =>
                (user.Username == model.Username.Trim())
            && user.Password == hashedPassword)))
            {
                return this.BadRequestErrorWithView("Invalid user information!");
            }
            else
            {
                var user = this.DbContext.Users.First(u => u.Username == model.Username);
                
                //Adding cookie
                var mvcUser = new MvcUserInfo { Username = user.Username, Role = user.Role.ToString() };
                var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);
                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, cookieContent);

                this.Request.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookie);
            }

            return this.Redirect("/");
        }
        
        [Authorize]
        public IHttpResponse Logout()
        {
            if (this.Request.Cookies.ContainsCookie(AuthenticationCookieKey))
            {
                var cookie = this.Request.Cookies.GetCookie(AuthenticationCookieKey);
                cookie.Delete();
                this.Response.AddCookie(cookie);
                return this.Redirect("/");
            }
            else
            {
                return this.Redirect("/Users/Login");
            }
        }
    }
}