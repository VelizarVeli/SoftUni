using SIS.HTTP.Headers;
using SIS.HTTP.Responses;
using System.Net;
using System.Text;

namespace SIS.WebServer.Results
{
    public class HtmlResults : HttpResponse
    {
        public HtmlResults(string content, HttpStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/html"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}