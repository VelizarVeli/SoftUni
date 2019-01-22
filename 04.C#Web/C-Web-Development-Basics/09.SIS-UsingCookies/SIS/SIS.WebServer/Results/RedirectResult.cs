using SIS.HTTP.Headers;
using SIS.HTTP.Responses;
using System.Net;

namespace SIS.WebServer.Results
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            : base(HttpStatusCode.Redirect)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}