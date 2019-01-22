namespace SIS.WebServer.Results
{
    using Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;
    using System.Text;

    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader(Constants.TextHeaderKey, Constants.TextHeaderValue));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}