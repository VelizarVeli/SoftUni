namespace SIS.HTTP.Responses
{
    using Common;
    using Contracts;
    using Cookies;
    using Cookies.Contracts;
    using Enums;
    using Extensions;
    using Headers;
    using Headers.Contracts;
    using System;
    using System.Linq;
    using System.Text;
    using static Common.GlobalConstants;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse() { }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));

            this.Headers.Add(header);
        }

        public void AddCookie(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));

            this.Cookies.Add(cookie);
        }

        public byte[] GetBytes()
            => Encoding
            .UTF8
            .GetBytes(this.ToString())
            .Concat(this.Content).ToArray();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .Append(HttpNewLine)
                .Append(this.Headers)
                .Append(HttpNewLine);
            
            if(this.Cookies.HasCookies())
            {
                foreach (HttpCookie httpCoookie in this.Cookies)
                    result
                        .Append($"Set-Cookie: {httpCoookie}")
                        .Append(HttpNewLine);
            }

            result
                .Append(HttpNewLine);

            return result.ToString();
        }
    }
}
