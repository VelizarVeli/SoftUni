using Http.Cookies.Contracts;
using Http.Enums;
using Http.Headers.Contracts;
using Http.Sessions.Contracts;
using System.Collections.Generic;

namespace Http.Requests.Contracts
{
    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormDate { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        HttpRequestMethod RequestMethod { get; }

        IHttpSession Session { get; set; }

    }
}
