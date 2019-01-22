using System;
using System.Linq;
using IRunesWebApp.Models;
using Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class UsersController : BaseController
    {
        private readonly HashService hashService;

        public UsersController()
        {
            this.hashService = new HashService();
        }

        public IHttpResponse Login(IHttpRequest request) => this.View();

        public IHttpResponse PostLogin(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString();
            var password = request.FormData["password"].ToString();

            var hashedPassword = this.hashService.Hash(password);

            var user = this.Context.Users
                .FirstOrDefault(u => u.Username == username &&
                    u.HashedPassword == hashedPassword);

            if (user == null)
            {
                return new RedirectResult("/login");
            }

            var response = new RedirectResult("/home/index");
            this.SignInUser(username, response, request);
            return response;
        }

        public IHttpResponse Register(IHttpRequest request) => this.View();

        public IHttpResponse PostRegister(IHttpRequest request)
        {
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();

            if (password != confirmPassword)
            {
                return new BadRequestResult(
                    "Passwords do not match.",
                    HttpResponseStatusCode.SeeOther);
            }

            var hashedPassword = this.hashService.Hash(password);

            var user = new User
            {
                Username = userName,
                HashedPassword = hashedPassword,
            };
            this.Context.Users.Add(user);

            try
            {
                this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                return new BadRequestResult(
                    e.Message,
                    HttpResponseStatusCode.InternalServerError);
            }

            var response = new RedirectResult("/");
            this.SignInUser(userName, response, request);

            return response;
        }


    }
}
