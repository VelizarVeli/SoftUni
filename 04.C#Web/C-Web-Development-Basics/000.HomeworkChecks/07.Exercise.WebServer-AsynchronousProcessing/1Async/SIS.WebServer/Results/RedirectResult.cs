namespace SIS.WebServer.Results
{
    using HTTP.Responses;
    using HTTP.Enums;
    using HTTP.Headers;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}
