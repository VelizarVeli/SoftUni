namespace SIS.WebServer.Results
{
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;

    public class FileResult : HttpResponse
    {
        public FileResult(byte[] content)
        {
            this.Headers.Add(new HttpHeader("Content-Length", content.Length.ToString()));
            this.Headers.Add(new HttpHeader("Content-Disposition", "inline"));
            this.Content = content;
        }
    }
}
