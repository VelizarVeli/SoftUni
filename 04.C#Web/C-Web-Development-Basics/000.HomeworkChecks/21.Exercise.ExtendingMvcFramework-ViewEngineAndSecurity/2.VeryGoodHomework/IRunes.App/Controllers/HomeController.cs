using IRunes.App.Common;
using IRunes.App.Controllers.Contracts;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes;
using SIS.Framework.Controllers;

namespace IRunes.App.Controllers
{
    public class HomeController : Controller, IHomeController
    {
	[HttpGet]
	public IActionResult Index()
	{
	    ViewModel[Constants.UsernameKey] = Identity != null
		? Identity.Username
		: Constants.DefaultUsername;
	    return View();
	}
    }
}
