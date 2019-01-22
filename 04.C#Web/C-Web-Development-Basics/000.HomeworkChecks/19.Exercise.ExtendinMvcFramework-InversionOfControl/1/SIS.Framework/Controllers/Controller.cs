namespace SIS.Framework.Controllers
{
    using ActionResults;
    using ActionResults.Contracts;
    using HTTP.Requests.Contracts;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Utilities;
    using ViewModels;
    using Views;

    public abstract class Controller
    {
        protected IDictionary<string, string> ViewBag;

        protected Controller()
        {
            this.Model = new ViewModel();
            this.ViewBag = new Dictionary<string, string>();
        }

        protected ViewModel Model { get; }

        public Model ModelState { get; } = new Model();

        public IHttpRequest Request { get; set; }

        protected IViewable View([CallerMemberName] string viewName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);
            var fullPath = ControllerUtilities.GetViewPath(controllerName, viewName);
            var view = new View(fullPath, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl) => new RedirectResult(redirectUrl);

        public bool IsAuthenticated()
        {
            return this.Request.Session.ContainsParameter("username");
        }
    }
}