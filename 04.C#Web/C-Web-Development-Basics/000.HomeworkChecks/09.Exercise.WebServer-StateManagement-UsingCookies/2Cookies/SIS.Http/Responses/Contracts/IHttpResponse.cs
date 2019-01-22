using System.Net;
using SIS.Http.Cookies;
using SIS.Http.Cookies.Contracts;
using SIS.Http.Enum;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;

namespace SIS.Http.Responses.Contracts
{
    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeadersCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        void AddCookie(HttpCookie cookie);

        byte[] GetBytes();
    }
}
