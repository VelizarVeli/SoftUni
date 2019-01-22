using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class HomeController : BaseController
    {
        

        public IHttpResponse Index(IHttpRequest request)
        {
            if (request.Session.ContainsParameter("username"))
            {
                var username = request.Session.GetParameter("username").ToString();
                this.ViewBag["username"] = username;
                return this.View(request, "IndexLoggedIn");
            }
            return this.View(request);
        }

    }
}
