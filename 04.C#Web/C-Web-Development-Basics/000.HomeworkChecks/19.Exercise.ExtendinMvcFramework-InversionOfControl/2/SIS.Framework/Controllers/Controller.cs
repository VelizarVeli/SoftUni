using SIS.Framework.ActionResults;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Models;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Extensions;
using SIS.HTTP.Requests;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        public IHttpRequest Request { get; set; }

        public ViewModel ViewModel { get; set; }

        public Model ModelState { get; } = new Model();

        protected Controller()
        {
            this.ViewModel = new ViewModel();
        }

        protected IViewable View([CallerMemberName] string viewName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            if (viewName == "Index")
            {
                viewName = this.Request.IsLoggedIn() ? "IndexLoggedIn" : "IndexLoggedOut";
            }

            var viewFullyQualifiedName = ControllerUtilities.GetViewFullyQualifiedName(controllerName, viewName);

            var layoutFullyQualifiedName = ControllerUtilities.GetLayoutFullyQualifiedName("_Layout");

            var view = new View(viewFullyQualifiedName, layoutFullyQualifiedName, this.ViewModel.Data, this.Request.IsLoggedIn());

            return new ViewResult(view);
        }

        protected IViewable Error(string errorMessage)
        {
            this.ViewModel["Error"] = errorMessage;

            var viewFullyQualifiedName = ControllerUtilities.GetLayoutFullyQualifiedName("Error");

            var layoutFullyQualifiedName = ControllerUtilities.GetLayoutFullyQualifiedName("_Layout");

            var view = new View(viewFullyQualifiedName, layoutFullyQualifiedName, this.ViewModel.Data, this.Request.IsLoggedIn());

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl) => new RedirectResult(redirectUrl);
    }
}
