namespace SIS.IRunesApp.Controllers
{
    using HTTP.Requests;
    using HTTP.Responses;
    using IRunesApp.Extensions;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {

        public IHttpResponse Index(IHttpRequest request)
        {
            if (!request.IsLoggedIn())
            {
                return this.View("Home/IndexLoggedOut", request);
            }
            Dictionary<string, string> dict = new Dictionary<string, string> { { "Username", request.GetUsername() } };

            return this.View("Home/IndexLoggedIn", request, dict);
        }
    }
}
