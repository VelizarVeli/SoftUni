namespace SIS.HTTP.Responses
{
    using System.Linq;
    using System.Text;
    using Common;
    using Contracts;
    using Cookies;
    using Cookies.Contracts;
    using Enums;
    using Extensions;
    using Headers;
    using Headers.Contracts;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
        }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));

            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
            this.Cookies = new HttpCookieCollection();
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public byte[] Content { get; set; }

        public IHttpCookieCollection Cookies { get; private set; }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));

            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public void AddCookie(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));

            this.Cookies.Add(cookie);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GlobalConstans.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .AppendLine(this.Headers.ToString());

            if (this.Cookies.HasCookies())
            {
                foreach (var httpCookie in this.Cookies)
                {
                    sb.AppendLine($"Set-Cookie: {this.Cookies}");
                }
            }

            sb.AppendLine();

            return sb.ToString();
        }
    }
}