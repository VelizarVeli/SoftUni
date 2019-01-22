using SIS.HTTP.Headers;
using SIS.HTTP.Responses;
using System.Text;

namespace SIS.WebServer.Results
{
    public class UnauthorizedResult : HttpResponse
    {
        private const string DefaultErrorHandling = "<h1>You have no permission to access this functionality.</h1>";

        public UnauthorizedResult()
            :base(HTTP.Enums.HttpResponseStatusCode.Unauthorized)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/html"));
            this.Content = Encoding.UTF8.GetBytes(DefaultErrorHandling);
        }
    }
}