using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request) => this.View();
    }
}
