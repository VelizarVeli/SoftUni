namespace SIS.IRunesApp.Controllers
{
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using IRunesApp.Data.Models;
    using IRunesApp.Extensions;
    using IRunesApp.Services;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class UsersController : BaseController
    {
        private IHashService hashService;

        public UsersController()
        {
            this.hashService = new HashService();
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            if (request.IsLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View("Users/Login", request);
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            if (request.IsLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View("Users/Register", request);
        }

        public IHttpResponse DoLogin(IHttpRequest request)
        {
            if (request.IsLoggedIn())
            {
                return this.Redirect("/");
            }
            string login = (string)request.FormData["login"];
            string password = (string)request.FormData["password"];

            User user = this.Db.Users.First(u => u.Username.ToLower() == login || u.Email.ToLower() == login);

            if (user == null)
            {

                return this.Error("Invalid login or password", HttpResponseStatusCode.Forbidden, request);
            }

            string base64Hash = user.Password;

            if (!this.hashService.IsPasswordValid(password, base64Hash))
            {
                return this.Error("Invalid login or password", HttpResponseStatusCode.Forbidden, request);
            }

            request.Session.AddParameter("username", user.Username);
            return this.Redirect("/");
        }

        public IHttpResponse DoRegister(IHttpRequest request)
        {
            if (request.IsLoggedIn())
            {
                return this.Redirect("/");
            }

            string username = (string)request.FormData["username"];
            string password = (string)request.FormData["password"];
            string confirmPassword = (string)request.FormData["confirmPassword"];
            string email = (string)request.FormData["email"];

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(email))
            {
                return this.Error("All fields are required", HttpResponseStatusCode.BadRequest, request);
            }

            if (!Regex.IsMatch(username, "^[A-Za-z0-9_.-]+$"))
            {
                return this.Error("Username can only contain the following characters: A-Z a-z 0-9 - . _",
                    HttpResponseStatusCode.BadRequest, request);
            }

            if (password != confirmPassword)
            {
                return this.Error("Passwords do not match", HttpResponseStatusCode.BadRequest, request);
            }

            if (this.Db.Users.Any(u => u.Username.ToLower() == username))
            {
                return this.Error("Username is already taken", HttpResponseStatusCode.BadRequest, request);
            }

            if (this.Db.Users.Any(u => u.Email.ToLower() == email))
            {
                return this.Error("An account with this email already exists", HttpResponseStatusCode.BadRequest,
                    request);
            }

            string base64Hash = this.hashService.HashPassword(password, this.hashService.GenerateSalt());

            User user = new User
            {
                Username = username,
                Email = email,
                Password = base64Hash
            };

            this.Db.Users.Add(user);
            this.Db.SaveChanges();

            request.Session.AddParameter("username", user.Username);
            return this.Redirect("/");
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            if (request.IsLoggedIn())
            {
                request.Session.RemoveParameter("username");
            }

            return this.Redirect("/");
        }
    }
}
