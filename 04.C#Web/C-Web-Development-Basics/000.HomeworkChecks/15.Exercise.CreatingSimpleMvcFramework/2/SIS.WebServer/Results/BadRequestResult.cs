namespace SIS.WebServer.Results
{
    using System.Text;
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;

    public class BadRequestResult : HttpResponse
    {
        public BadRequestResult(HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            var content = "<h1>404 Page Not Found Error</h1>";
            this.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/html"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}