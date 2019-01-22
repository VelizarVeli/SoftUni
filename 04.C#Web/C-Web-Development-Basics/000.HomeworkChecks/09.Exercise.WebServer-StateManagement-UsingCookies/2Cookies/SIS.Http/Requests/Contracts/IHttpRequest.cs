using System.Collections.Generic;
using SIS.Http.Cookies.Contracts;
using SIS.Http.Enum;
using SIS.Http.Headers.Contracts;
using SIS.Http.Sessions;

namespace SIS.Http.Requests.Contracts
{
    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeadersCollection Headers { get; }

        IHttpCookieCollection Cookie { get; }

        HttpRequestMethod RequestMethod { get; }

        IHttpSession Session { get; set; }
    }
}
