namespace IRunes.Controllers
{
    using IRunes.Models;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Sessions;
    using SIS.WebServer.Results;
    using System;
	using System.Collections.Generic;
	using System.Text;
	

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            Dictionary<string, string> viewBag = new Dictionary<string, string>(HttpSessionStorage.GuestViewBag);

            if (request.Session.ContainsParameter("uData"))
            {
                var username = (request.Session.GetParameter("uData") as User).Username;
                viewBag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag)
                {
                    ["Name"]= username,
                };
            }

            return this.View("Home",viewBag);
        }
    }
}