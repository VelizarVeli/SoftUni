using System.Net;
using System.Text;
using SIS.Http.Enum;
using SIS.Http.Headers;
using SIS.Http.Responses;

namespace SIS.WebServer.Results
{
    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode responseStatuCode)
            : base(responseStatuCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/plain"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
