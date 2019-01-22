using SIS.HTTP.Cookies;
using SIS.HTTP.Headers;
using System.Net;

namespace SIS.HTTP.Responses
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        void AddCookie(HttpCookie cookie);

        byte[] GetBytes();
    }
}