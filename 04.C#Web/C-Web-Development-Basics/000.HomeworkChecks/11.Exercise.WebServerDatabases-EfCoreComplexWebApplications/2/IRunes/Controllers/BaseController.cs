namespace IRunes.Controllers
{
    using IRunes.Data;
    using IRunes.Services;
    using IRunes.Services.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.WebServer.Results;
    using System;
	using System.Collections.Generic;
    using System.IO;
    using System.Text;
	
    public abstract class BaseController
    {
        protected BaseController()
        {
            this.Db = new IRunesDbContext();
            this.UserCookieService = new UserCookieService();
        }

        protected IRunesDbContext Db { get; }

        protected IUserCookieService UserCookieService { get; }

        protected string GetUsername(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-runes"))
            {
                return null;
            }

            var cookie = request.Cookies.GetCookie(".auth-runes");
            var cookieContent = cookie.Value;
            var userName = this.UserCookieService.GetUserData(cookieContent);
            return userName;

        }

        protected IHttpResponse View(string viewName, IDictionary<string, string> viewBag = null)
        {
            if (viewBag == null)
            {
                viewBag = new Dictionary<string, string>();
            }

            var allContent = this.GetViewContent(viewName, viewBag);
            return new HtmlResult(allContent, HttpResponseStatusCode.Ok);
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            var viewBag = new Dictionary<string, string>();
            viewBag.Add("Error", errorMessage);
            var allContent = this.GetViewContent("Error", viewBag);

            return new HtmlResult(allContent, HttpResponseStatusCode.BadRequest);
        }

        protected IHttpResponse ServerError(string errorMessage)
        {
            var viewBag = new Dictionary<string, string>();
            viewBag.Add("Error", errorMessage);
            var allContent = this.GetViewContent("Error", viewBag);

            return new HtmlResult(allContent, HttpResponseStatusCode.InternalServerError);
        }

        private string GetViewContent(string viewName,
            IDictionary<string, string> viewBag)
        {
            var layoutContent = File.ReadAllText("../../../Views/Layout.html");
            
            var content = File.ReadAllText("../../../Views/" + viewName + ".html");

            content = layoutContent.Replace("@RenderBody()", content);

            foreach (var item in viewBag)
            {
                content = content.Replace("@Model." + item.Key, item.Value);
            }

            //var allContent = layoutContent.Replace("@RenderBody()", content);
            return content;
        }
    }
}