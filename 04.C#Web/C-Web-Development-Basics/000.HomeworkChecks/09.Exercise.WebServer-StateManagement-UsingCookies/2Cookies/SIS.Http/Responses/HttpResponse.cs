using System;
using System.Linq;
using System.Net;
using System.Text;
using SIS.Http.Common;
using SIS.Http.Cookies;
using SIS.Http.Cookies.Contracts;
using SIS.Http.Extensions;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;
using SIS.Http.Responses.Contracts;
using SIS.Http.Enum;


namespace SIS.Http.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse() { }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            Headers = new HttpHeadersCollection();
            Cookies = new HttpCookiesCollection();
            Content = new byte[0];
            StatusCode = statusCode;
        } 


        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeadersCollection Headers { get; private set; }

        public IHttpCookieCollection Cookies { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public void AddCookie(HttpCookie cookie)
        {
            this.Cookies.Add(cookie);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}") 
                .Append(Environment.NewLine)
                .Append($"{this.Headers}");/*.Append(Environment.NewLine) // ?  
                .Append(Environment.NewLine);*/

            if (this.Cookies.HasCookies())
            {
                result.AppendLine($"{GlobalConstants.CookieRequestHeaderName}: {this.Cookies}");
            }

            return result.ToString();
        }
    }
}
