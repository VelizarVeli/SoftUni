using Http.Headers;
using Http.Responses;
using System.Net;
using System.Text;

namespace WebServer.Results
{
    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpStatusCode responseStatusCode)
            :base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/plain"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
