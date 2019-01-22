namespace SIS.MVC.Framework.Controllers
{
    using Common;
    using HTTP.Cookies;
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Controller
    {
        protected IDictionary<string, string> ViewBag;

        public Controller()
        {
            this.ViewBag = new Dictionary<string, string>();
            this.Response = new HttpResponse(HttpResponseStatusCode.Ok);
        }

        public IHttpRequest Request { get; set; }

        public IHttpResponse Response { get; set; }

        public IUserCookieService UserCookieService { get; internal set; }

        //protected string Username
        //{
        //    get
        //    {
        //        if (!this.Request.Cookies.ContainsCookie(Constants.HttpCookieKey))
        //        {
        //            return null;
        //        }

        //        var cookie = this.Request.Cookies.GetCookie(Constants.HttpCookieKey).Value;
        //        return this.UserCookieService.GetUserData(cookie);
        //    }
        //}

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            var filePath = Constants.FolderViewsRelativePath
                           + this.GetCurrentControllerName() + "/"
                           + viewName + Constants.HtmlFileExtension;

            if (!File.Exists(filePath))
            {
                this.PrepareHtmlResult(string.Format(Messages.ViewNotFound, viewName));
                this.Response.StatusCode = HttpResponseStatusCode.Found;
                return this.Response;
            }

            string fileContent = this.BuildViewContent(filePath);

            this.PrepareHtmlResult(fileContent);

            return this.Response;
        }

        private string BuildViewContent(string filePath)
        {
            var fileContent = File.ReadAllText(filePath);

            foreach (var viewBagKey in this.ViewBag.Keys)
            {
                var dataPlaceholder = $"{{{{{viewBagKey}}}}}";
                if (fileContent.Contains(dataPlaceholder))
                {
                    fileContent = fileContent.Replace(dataPlaceholder, this.ViewBag[viewBagKey]);
                }
            }

            return fileContent;
        }

        private string GetCurrentControllerName() => this.GetType().Name.Replace(Constants.ControllerName, string.Empty);

        public bool IsAuthenticated()
        {
            return this.Request.Session.ContainsParameter("username");
        }

        public void SignInUser(string username)
        {
            this.Request.Session.AddParameter("username", username);
            var userCookie = this.UserCookieService.GetUserCookie(username);
            this.Response.Cookies.Add(new HttpCookie(Constants.HttpCookieKey, userCookie));
        }

        protected IHttpResponse FileResult(byte[] content)
        {
            this.Response.Headers.Add(new HttpHeader(Constants.ContentLength, content.Length.ToString()));
            this.Response.Headers.Add(new HttpHeader(Constants.ContentDisposition, "inline"));
            this.Response.Content = content;

            return this.Response;
        }

        protected IHttpResponse RedirectResult(string location)
        {
            this.Response.Headers.Add(new HttpHeader(Constants.RedirectHeaderKey, location));
            this.Response.StatusCode = HttpResponseStatusCode.SeeOther;

            return this.Response;
        }

        protected IHttpResponse TextResult(string content)
        {
            this.Response.Headers.Add(new HttpHeader(Constants.TextHeaderKey, Constants.TextHeaderValue));
            this.Response.Content = Encoding.UTF8.GetBytes(content);

            return this.Response;
        }

        private void PrepareHtmlResult(string content)
        {
            this.Response.Headers.Add(new HttpHeader(Constants.HtmlHeaderKey, Constants.HtmlHeaderValue));
            this.Response.Content = Encoding.UTF8.GetBytes(content);
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            this.PrepareHtmlResult($"<h1>{errorMessage}</h1>");
            this.Response.StatusCode = HttpResponseStatusCode.BadRequest;

            return this.Response;
        }

        protected IHttpResponse ServerError(string errorMessage)
        {
            this.PrepareHtmlResult($"<h1>{errorMessage}</h1>");
            this.Response.StatusCode = HttpResponseStatusCode.InternalServerError;

            return this.Response;
        }
    }
}