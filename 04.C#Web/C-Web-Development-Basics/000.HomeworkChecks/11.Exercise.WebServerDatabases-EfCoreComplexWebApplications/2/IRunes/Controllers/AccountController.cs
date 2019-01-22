namespace IRunes.Controllers
{
    using IRunes.Models;
    using IRunes.Services.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Sessions;
    using SIS.WebServer.Results;
    using System;
	using System.Collections.Generic;
    using System.Linq;
    using System.Text;
	
    public class AccountController : BaseController
    {
        private IHashService hashService;

        public AccountController()
        {
            this.hashService = new HashService();
        }

        //public IHttpResponse Login(IHttpRequest request)
        //{
        //    var viewbag = new Dictionary<string, string>(HttpSessionStorage.GuestViewBag);

        //    if (request.Session.ContainsParameter("uData"))
        //    {
        //        viewbag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag);
        //    }

        //    return this.View("Login");
        //}

        public IHttpResponse Login(IHttpRequest request)
        {
            if (request.RequestMethod == SIS.HTTP.Enums.HttpRequestMethod.Post)
            {
                string userName = request.FormData["username"].ToString().Trim();
                string password = request.FormData["password"].ToString();

                string hashedPassword = this.hashService.Hash(password);

                User user = this.Db.Users.FirstOrDefault(x =>
                    x.Username == userName &&
                    x.Password == hashedPassword);

                if (user == null)
                {
                    return this.BadRequestError("Invalid username or password.");
                }

                string cookieContent = this.UserCookieService.GetUserCookie(user.Username);

                request.Session.AddParameter("uData", user);

                RedirectResult response = new RedirectResult("/");
                HttpCookie cookie = new HttpCookie(".auth-irunes", cookieContent, 7) { HttpOnly = true };
                response.Cookies.Add(cookie);
                return response;
            }
            
            var viewbag = new Dictionary<string, string>(HttpSessionStorage.GuestViewBag);

            if (request.Session.ContainsParameter("uData"))
            {
                viewbag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag);
            }

            return this.View("Login", viewbag);
        }

        public IHttpResponse Register()
        {
            return this.View("Register");
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            string userName = request.FormData["username"].ToString().Trim();
            string password = request.FormData["password"].ToString();
            string confirmPassword = request.FormData["confirm_password"].ToString();
            string email = request.FormData["email"].ToString();

            // Validate
            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4)
            {
                return this.BadRequestError("Please provide valid username with length of 4 or more characters.");
            }

            if (this.Db.Users.Any(x => x.Username == userName))
            {
                return this.BadRequestError("User with the same name already exists.");
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return this.BadRequestError("Please provide password of length 6 or more.");
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError("Passwords do not match.");
            }

            // Hash password
            string hashedPassword = this.hashService.Hash(password);

            // Create user
            User user = new User
            {
                Username = userName,
                Email = email,
                Password = hashedPassword,
            };
            this.Db.Users.Add(user);

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            // TODO: Login

            // Redirect
            return new RedirectResult("/");
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-irunes"))
            {
                return new RedirectResult("/");
            }

            var cookie = request.Cookies.GetCookie(".auth-irunes");
            cookie.Delete();
            var response = new RedirectResult("/");
            response.Cookies.Add(cookie);
            return response;
        }
    }
}