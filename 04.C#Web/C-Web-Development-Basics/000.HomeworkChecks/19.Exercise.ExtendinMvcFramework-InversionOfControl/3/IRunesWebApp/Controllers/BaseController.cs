using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using IRunesWebApp.Data;
using Services;
using SIS.Framework.Controllers;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IDictionary<string, string> ViewBag { get; set; }

        private const string RootDirectoryRelativePath = "../../../";

        private const string ViewsFolderName = "Views";

        private const string HtmlFileExtension = ".html";

        private const string DirectorySeparator = "/";

        private const string LayoutViewFileName = "_Layout";

        private const string RenderBodyConstant = "@RenderBody()";

        private const string NavigationModelConstant = "@Model.Navigation";

        private const string NavigationLoggedInDirectory = "../../../Navigation/NavigationLoggedIn.html";

        private const string NavigationLoggedOutDirectory = "../../../Navigation/NavigationLoggedOut.html";

        private string GetCurrentControllerName() =>
            this.GetType().Name.Replace("Controller", string.Empty);

        protected IRunesContext Context { get; set; }

        protected readonly UserCookieService userCookieService;

        private bool isAuthenticated { get; set; }

        public BaseController()
        {
            this.Context = new IRunesContext();
            this.userCookieService = new UserCookieService();
            this.ViewBag = new Dictionary<string, string>();
        }

        protected bool IsAuthenticated(IHttpRequest request)
        {
            isAuthenticated = request.Session.ContainsParameter("username");
            return isAuthenticated;
        }

        public void SignInUser(string username, IHttpResponse response, IHttpRequest request)
        {
            request.Session.AddParameter("username", username);
            var UserCookieValue = this.userCookieService.GetUserCookie(username);
            response.Cookies.Add(new HttpCookie("IRunes_auth", UserCookieValue));
        }

        protected IHttpResponse ViewMethod([CallerMemberName] string viewName = "")
        {
            var layoutView = RootDirectoryRelativePath +
                         ViewsFolderName +
                         DirectorySeparator +
                         LayoutViewFileName +
                         HtmlFileExtension;

            string filePath = RootDirectoryRelativePath +
                ViewsFolderName +
                DirectorySeparator +
                this.GetCurrentControllerName() +
                DirectorySeparator +
                viewName +
                HtmlFileExtension;



            if (!File.Exists(filePath))
            {
                return new BadRequestResult(
                    $"View {viewName} not found.",
                    HttpResponseStatusCode.NotFound);
            }

            var viewContent = BuildViewContent(filePath);

            var viewLayout = File.ReadAllText(layoutView);

            var view = viewLayout.Replace(RenderBodyConstant, viewContent);

            if (isAuthenticated)
            {
                view = view.Replace(NavigationModelConstant, File.ReadAllText(NavigationLoggedInDirectory));
            }
            else
            {
                view = view.Replace(NavigationModelConstant, File.ReadAllText(NavigationLoggedOutDirectory));
            }

            var response = new HtmlResult(view, HttpResponseStatusCode.Ok);

            return response;
        }

        private string BuildViewContent(string filePath)
        {
            var viewContent = File.ReadAllText(filePath);

            foreach (var viewBagKey in ViewBag.Keys)
            {
                var dynamicDataPlaceHolder = $"{{{{{viewBagKey}}}}}";
                if (viewContent.Contains(dynamicDataPlaceHolder))
                {
                    viewContent = viewContent.Replace(
                        dynamicDataPlaceHolder,
                        this.ViewBag[viewBagKey]);
                }
            }
            return viewContent;
        }

    }
}
