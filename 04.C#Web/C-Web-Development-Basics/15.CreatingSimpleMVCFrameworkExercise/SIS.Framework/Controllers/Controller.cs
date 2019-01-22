namespace SIS.Framework.Controllers
{
    using Framework.ActionResults;
    using Framework.Utilities;
    using Framework.Views;
    using HTTP.Requests;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Controller()
        {
        }

        public IHttpRequest Request { get; set; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            string controllerName = ControllerUtilities.GetControllerName(this);

            string fullyQualifiedName = ControllerUtilities.GetViewFullyQualifiedName(controllerName, caller);

            View view = new View(fullyQualifiedName);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
            => new RedirectResult(redirectUrl);
    }
}
