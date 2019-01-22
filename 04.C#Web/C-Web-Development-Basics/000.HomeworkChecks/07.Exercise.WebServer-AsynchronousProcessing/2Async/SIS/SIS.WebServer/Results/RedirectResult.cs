using System.Net;
using System.Text;
using SIS.Http.Headers;
using SIS.Http.Responses;

namespace SIS.WebServer.Results
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string Location)
            : base(HttpStatusCode.Redirect)
        {
            this.Headers.Add(new HttpHeader("Location", Location));
            
        }
    }
}