namespace SIS.Framework.Controllers
{
    using ActionResults;
    using ActionResults.Contracts;
    using HTTP.Requests.Contracts;
    using Models;
    using System.Runtime.CompilerServices;
    using Utilities;
    using Views;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
        }

        protected ViewModel Model { get; }

        public Model ModelState { get; } = new Model();

        public IHttpRequest Request { get; set; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            string controllerName = ControllerUtilites.GetControllerName(this);

            string fullyQualifiedName = ControllerUtilites.GetViewFullQualifiedName(controllerName, caller);

            IRenderable view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
            => new RedirectResult(redirectUrl);
    }
}
