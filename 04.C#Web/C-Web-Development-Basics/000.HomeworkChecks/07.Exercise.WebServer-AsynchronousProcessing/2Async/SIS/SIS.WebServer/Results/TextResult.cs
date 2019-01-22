using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using SIS.Http.Headers;
using SIS.Http.Responses;

namespace SIS.WebServer.Results
{
    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpStatusCode statusCode)
            : base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content.Type", "text/plain"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
