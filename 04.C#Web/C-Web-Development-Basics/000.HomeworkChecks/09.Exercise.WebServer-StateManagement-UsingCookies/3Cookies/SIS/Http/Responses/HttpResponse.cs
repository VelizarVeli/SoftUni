using Http.Cookies;
using Http.Cookies.Contracts;
using Http.Extensions;
using Http.Headers;
using Http.Headers.Contracts;
using Http.Responses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Http.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {

        }

        public HttpResponse(HttpStatusCode statusCode)
        {
            Headers = new HttpHeaderCollection();
            Cookies = new HttpCookieCollection();
            Content = new byte[0];
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; set; }

        public byte[] Content { get; set; }

        public IHttpCookieCollection Cookies { get; set; }

        public void AddHeader(HttpHeader head)
        {
            Headers.Add(head);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{Common.GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .AppendLine($"{this.Headers}");
            if (this.Cookies.HasCookies())
            {
                result.Append($"Set-Cookie: {this.Cookies}").Append(Environment.NewLine);
            }

            result.AppendLine(Environment.NewLine);

            return result.ToString();
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(Content).ToArray();
        }

        public void AddCookie(HttpCookie cookie)
        {
            Cookies.Add(cookie);
        }
    }
}
