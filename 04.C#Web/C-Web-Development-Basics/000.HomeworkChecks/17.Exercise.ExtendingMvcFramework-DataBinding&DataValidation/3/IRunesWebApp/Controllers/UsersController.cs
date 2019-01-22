using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            hashService = new HashService();
        }

        public IHttpResponse Login(IHttpRequest request) => this.View(request);

        public IHttpResponse PostLogin(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString();
            var password = request.FormData["password"].ToString();

            

            var hashedPassword = this.hashService.Hash(password);

            var user = this.Context.Users
                .FirstOrDefault(u => u.Username == username
                            && u.HashedPassword == hashedPassword);

            if (user == null)
            {
                return new RedirectResult("/users/login");
            }

            
            
            request.Session.AddParameter("username", user.Username);
            return new RedirectResult("/");

        }

        public IHttpResponse PostRegister(IHttpRequest request)
        {
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();

            if (password != confirmPassword)
            {
                return new BadRequestResult("Passwords do not match.", HttpResponseStatusCode.SeeOther);
            }

            // Hash password
            var hashedPassword = this.hashService.Hash(password);

            // Create user
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
                // TODO: Log error
                return new BadRequestResult(e.Message, HttpResponseStatusCode.InternalServerError);
            }

            request.Session.AddParameter("username", user.Username);
            return new RedirectResult("/");
        }

        public IHttpResponse Register(IHttpRequest request) => this.View(request);

        public IHttpResponse Logout(IHttpRequest request)
        {
            if (this.IsAuthenticated(request))
            {
                request.Session.RemoveParameter("username");
            }

            return new RedirectResult("/");
        }
    }
}
