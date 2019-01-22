using Http.Cookies;
using Http.Cookies.Contracts;
using Http.Headers;
using Http.Headers.Contracts;
using System.Net;

namespace Http.Responses.Contracts
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        void AddCookie(HttpCookie cookie);

        byte[] Content { get; set; }

        void AddHeader(HttpHeader head);

        byte[] GetBytes();
    }
}
