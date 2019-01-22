namespace SIS.WebServer.Results
{
    using Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;
    using System.Text;

    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode statusCode)
            : base(statusCode)
        {
            this.Headers.Add(new HttpHeader(Constants.HtmlHeaderKey, Constants.HtmlHeaderValue));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}