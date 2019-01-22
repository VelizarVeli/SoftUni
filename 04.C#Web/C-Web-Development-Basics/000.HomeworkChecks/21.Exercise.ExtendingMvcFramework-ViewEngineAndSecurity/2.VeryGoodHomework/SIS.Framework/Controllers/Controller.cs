using System.Reflection;
using System.Runtime.CompilerServices;
using SIS.Framework.ActionResults;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Common;
using SIS.Framework.Controllers.Contracts;
using SIS.Framework.Models;
using SIS.Framework.Models.Contracts;
using SIS.Framework.Security;
using SIS.Framework.Security.Contracts;
using SIS.Framework.Views;
using SIS.Framework.Views.Contracts;
using SIS.HTTP.Requests.Contracts;

namespace SIS.Framework.Controllers
{
    public abstract class Controller : IController
    {
	private ViewEngine ViewEngine { get; } = new ViewEngine();

	public Controller()
	{
	    ViewModel = new ViewModel();
	}

	public IModel ModelState { get; } = new Model();
	public string Name => GetType().Name
	    .Replace(MvcContext.Get.ControllersSuffix, string.Empty);
	public IIdentity Identity => (IIdentity)Request.Session
	    .GetParameter(Constants.IdentityKey);
	public IHttpRequest Request { get; set; }
	protected ViewModel ViewModel { get; }

	protected IActionResult BadRequest(string reason)
	{
	    IBadRequestResult badRequestResult = new BadRequestResult(reason);
	    return badRequestResult;
	}

	protected IActionResult NotFound(string resourceType, string resourceName)
	{
	    INotFoundResult notFoundResult = new NotFoundResult(resourceType, resourceName);
	    return notFoundResult;
	}

	protected IRedirectResult RedirectTo(string redirectUrl)
	    => new RedirectResult(redirectUrl);

	protected void SignIn(IIdentity identity)
	{
	    Request.Session.SetParameter(Constants.IdentityKey, identity);
	}

	protected void SignOut()
	{
	    var identity = (IdentityUser)Request.Session.GetParameter(Constants.IdentityKey);
	    if (identity != null) identity.IsAuthenticated = false;
	    Request.Session.SetParameter(Constants.IdentityKey, identity);
	}

	protected IViewResult Unauthorized(IViewModel viewModel = null, [CallerMemberName] string action = "")
	{
	    UpdateViewData(viewModel);
	    string content = ViewEngine.RenderHtml(Name, action, ViewModel.Data);
	    IRenderable view = new View(content);
	    IUnauthorizedResult unauthorizedResult = new UnauthorizedResult(view);
	    return unauthorizedResult;
	}

	protected IViewResult View(IViewModel viewModel = null, [CallerMemberName] string action = "")
	{
	    UpdateViewData(viewModel);
	    string content = ViewEngine.RenderHtml(Name, action, ViewModel.Data);
	    IRenderable view = new View(content);
	    IViewResult viewResult = new ViewResult(view);
	    return viewResult;
	}

	private void UpdateViewData(IViewModel viewModel)
	{
	    ViewModel[Constants.PageTitleKey] = Name;
	    ViewModel[Constants.IsAuthenticatedKey] = Identity != null
		? Identity.IsAuthenticated
		: false;
	    if (viewModel != null)
	    {
		if (viewModel.Data.Count > 0)
		{
		    foreach (var parameter in viewModel.Data)
		    {
			ViewModel[parameter.Key] = parameter.Value;
		    }
		}
		var viewModelProperties = viewModel.GetType().GetProperties(
		    BindingFlags.DeclaredOnly
		    | BindingFlags.Public
		    | BindingFlags.Instance);
		foreach (var property in viewModelProperties)
		{
		    var propertyValue = property.GetValue(viewModel);
		    if (propertyValue != null)
		    {
			ViewModel[property.Name] = propertyValue;
		    }
		}
	    }
	}
    }
}
