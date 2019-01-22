using SIS.Framework.Models.Contracts;
using SIS.Framework.Security.Contracts;
using SIS.HTTP.Requests.Contracts;

namespace SIS.Framework.Controllers.Contracts
{
    public interface IController
    {
	IModel ModelState { get; }
	string Name { get; }
	IIdentity Identity { get; }
	IHttpRequest Request { get; set; }
    }
}
