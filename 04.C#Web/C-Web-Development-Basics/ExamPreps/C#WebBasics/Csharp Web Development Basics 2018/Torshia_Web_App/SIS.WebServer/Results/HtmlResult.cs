namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode)
               : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/html;"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
