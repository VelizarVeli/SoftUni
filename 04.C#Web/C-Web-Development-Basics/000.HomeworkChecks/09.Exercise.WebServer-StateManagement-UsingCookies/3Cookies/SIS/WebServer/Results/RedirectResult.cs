using Http.Headers;
using Http.Responses;
using System.Net;
using System.Text;

namespace WebServer.Results
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string locatin)
            : base(HttpStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader("Location", locatin));
            
        }
    }
}
