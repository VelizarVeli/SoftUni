namespace SIS.WebServer.Results
{
    using Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;
    using System.Text;

    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader(Constants.HtmlHeaderKey, Constants.HtmlHeaderValue));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}