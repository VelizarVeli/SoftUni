using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;

namespace SIS.WebServer.Results
{
    public class InlineResourceResult : HttpResponse
    {
        
        public InlineResourceResult(byte[] content, HttpResponseStatusCode responseStatusCode) 
            : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader(HttpHeader.ContentLength, content.Length.ToString()));
            this.Headers.Add(new HttpHeader(HttpHeader.ContentType, "inline"));
            this.Content = content;
        }
    }
}
