using IRunes.Services;
using SIS.Framework.ActionResults;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Models;
using SIS.Framework.Security.Contracts;
using SIS.Framework.Services.Contracts;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Cookies;
using SIS.HTTP.Cookies.Contracts;
using SIS.HTTP.Requests.Contracts;
using System;
using System.Runtime.CompilerServices;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        public Controller()
        {
            this.Model = new ViewModel();
            this.Cookies = new HttpCookieCollection();
            this.UserCookieService = new UserCookieService();
        }

        public IUserCookieService UserCookieService { get; set; }

        public IHttpRequest Request { get; set; }

        public IIdentity Identity => (IIdentity)this.Request.Session.GetParameter("auth");

        public Model ModelState { get; } = new Model();

        private ViewEngine ViewEngine { get; } = new ViewEngine();

        public ViewModel Model { get; set; }

        public IHttpCookieCollection Cookies { get; set; }

        protected IViewable View([CallerMemberName] string viewName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);
            string viewContent = null;

            try
            {
                viewContent = this.ViewEngine.GetViewContent(controllerName, viewName);
            }
            catch (Exception e)
            {
                this.Model.Data["error"] = e.Message;

                viewContent = this.ViewEngine.GetErrorContent();
            }

            string renderedHtml = this.ViewEngine.RenderHtml(viewContent, this.Model.Data);
            var view = new View(renderedHtml);

            return new ViewResult(view);
        }

        protected void SignIn(IIdentity auth)
        {
            this.Request.Session.AddParameter("auth", auth);
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }
        
        private void SetViewBagParameters()
        {
            this.Model["NonAuthenticated"] = "";
            this.Model["Authenticated"] = "";

            if (this.User == null)
            {
                this.Model["Authenticated"] = "d-none";
            }
            else
            {
                this.Model["NonAuthenticated"] = "d-none";
            }
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
            => new RedirectResult(redirectUrl);

        protected string User
        {
            get
            {
                if (!this.Request.Cookies.ContainsCookie("_auth"))
                {
                    return null;
                }

                var cookie = this.Request.Cookies.GetCookie("_auth");
                var cookieContent = cookie.Value;
                var userName = this.UserCookieService.GetUserData(cookieContent);
                return userName;
            }
        }
    }
}