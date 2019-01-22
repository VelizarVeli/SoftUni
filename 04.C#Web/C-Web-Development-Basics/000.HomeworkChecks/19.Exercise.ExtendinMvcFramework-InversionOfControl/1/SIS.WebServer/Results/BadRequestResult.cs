namespace SIS.WebServer.Results
{
    using Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;
    using System;
    using System.Text;

    public class BadRequestResult : HttpResponse
    {
        public BadRequestResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            content = Constants.DefaultErrorHeading + Environment.NewLine + content;
            this.Headers.Add(new HttpHeader(Constants.HtmlHeaderKey, Constants.HtmlHeaderValue));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}