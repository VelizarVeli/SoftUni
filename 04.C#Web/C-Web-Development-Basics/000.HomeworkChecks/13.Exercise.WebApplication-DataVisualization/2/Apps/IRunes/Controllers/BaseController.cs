using CakesWebApp.Services;
using IRunes.Data;
using IRunes.Extensions;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace IRunes.Controllers
{
    public abstract class BaseController
    {
        private const string FolderPath = "Views/";

        protected IHttpResponse View(string viewName, IHttpRequest request, IDictionary<string, string> viewBag = null)
        {
            if (viewBag == null)
            {
                viewBag = new Dictionary<string, string>();
            }

            string allContent = this.GetViewContent(viewName, viewBag, request);

            HtmlResult result = new HtmlResult(allContent, HttpResponseStatusCode.Ok);
            return result;
        }

        protected IHttpResponse Error(string errorMessage, HttpResponseStatusCode statusCode, IHttpRequest request)
        {
            Dictionary<string, string> viewBag = new Dictionary<string, string>
            {
                {"Error", errorMessage}
            };

            string allContent = this.GetViewContent("Error", viewBag, request);

            HtmlResult result = new HtmlResult(allContent, statusCode);
            return result;
        }

        protected IHttpResponse Redirect(string location)
        {
            RedirectResult result = new RedirectResult(location);
            return result;
        }

        private string GetViewContent(string viewName,
            IDictionary<string, string> viewBag, IHttpRequest request)
        {
            string layoutContent = File.ReadAllText($"{FolderPath}_Layout.html");
            string content = File.ReadAllText($"{FolderPath}{viewName}.html");
            string allContent = layoutContent.Replace("@RenderBody()", content).Replace("@Model.Navigation", this.GetNavigation(request));

            foreach (var item in viewBag)
            {
                allContent = allContent.Replace("@Model." + item.Key, item.Value);
            }

            return allContent;
        }

        private string GetNavigation(IHttpRequest request)
        {
            string fileName = request.IsLoggedIn()
                ? "NavigationLoggedIn"
                : "NavigationLoggedOut";

            string path = File.ReadAllText($"{FolderPath}Navigation/{fileName}.html");
            return path;
        }
    }
}
