using System.Net;
using SIS.Http.Enum;
using SIS.Http.Headers;
using SIS.Http.Responses;

namespace SIS.WebServer.Results
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader("Location", "location"));
        }
    }
}
