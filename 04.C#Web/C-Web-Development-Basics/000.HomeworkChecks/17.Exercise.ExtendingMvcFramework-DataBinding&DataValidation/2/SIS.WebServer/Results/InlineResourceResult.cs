namespace SIS.WebServer.Results
{
    using Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;

    public class InlineResourceResult : HttpResponse
    {
        public InlineResourceResult(byte[] content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader(Constants.ContentLength, content.Length.ToString()));
            this.Headers.Add(new HttpHeader(Constants.ContentDisposition, "inline"));
            this.Content = content;
        }
    }
}