namespace IRunesApp.Controllers
{
    using Common;
    using Services;
    using SIS.Data;
    using SIS.Framework.Controllers;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using Constants = Common.Constants;

    public class BaseController : Controller
    {
        protected IDictionary<string, string> ViewBag;

        public BaseController()
        {
            this.Db = new RunesDbContext();
            this.UserCookieService = new UserCookieService();
            this.ViewBag = new Dictionary<string, string>();
        }

        protected RunesDbContext Db { get; }

        public UserCookieService UserCookieService { get; set; }

        protected IHttpResponse ViewMethod([CallerMemberName] string viewName = "")
        {
            var filePath = Constants.FolderViewsRelativePath
                           + this.GetCurrentControllerName() + "/"
                           + viewName + Constants.HtmlFileExtension;

            if (!File.Exists(filePath))
            {
                return new BadRequestResult(string.Format(Messages.ViewNotFound, viewName), HttpResponseStatusCode.Found);
            }

            string fileContent = this.BuildViewContent(filePath);

            return new HtmlResult(fileContent, HttpResponseStatusCode.Ok);
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

        public void SignInUser(string username, IHttpResponse response)
        {
            this.Request.Session.AddParameter("username", username);
            var userCookie = this.UserCookieService.GetUserCookie(username);
            response.Cookies.Add(new HttpCookie(Constants.HttpCookieKey, userCookie));
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpResponseStatusCode.BadRequest);
        }

        protected IHttpResponse ServerError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpResponseStatusCode.InternalServerError);
        }
    }
}