namespace IRunesWebApp.Controllers
{
    using Services;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.WebServer.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SIS.HTTP.Cookies;

    public class UsersController : BaseController
    {
        public IHttpResponse Login(IHttpRequest request) => this.View();

        public IHttpResponse PostLogin(IHttpRequest request)
        {

            var username = request.FormData["username"].ToString();
            var password = request.FormData["password"].ToString();
            var hashService = new HashService();
            var userCookieService = new UserCookieService();

            var hashedPassword = hashService.Hash(password);

            var user = this.Context.Users.FirstOrDefault(x => x.Username == username && x.HashedPassword == hashedPassword);

            if (user == null)
            {
                return new RedirectResult("/login");
            }

            request.Session.AddParameter("username", username);
            var userCookieValue = userCookieService.GetUserCookie(username);
            request.Cookies.Add(new HttpCookie("IRunes_auth", userCookieValue));
            return new RedirectResult("/home/index");
        }

     public IHttpResponse Register(IHttpRequest request) => this.View();

        //public IHttpResponse PostRegister(IHttpRequest request)
        //{

        //}
    }
}
