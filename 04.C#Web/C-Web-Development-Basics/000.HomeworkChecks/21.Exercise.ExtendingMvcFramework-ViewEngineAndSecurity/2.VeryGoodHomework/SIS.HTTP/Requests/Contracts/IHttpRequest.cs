using System.Collections.Generic;
using SIS.HTTP.Cookies.Contracts;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Sessions.Contracts;

namespace SIS.HTTP.Requests.Contracts
{
    public interface IHttpRequest
    {
	string Path { get; }
	string Url { get; }
	IHttpSession Session { get; set; }
	HttpRequestMethod Method { get; }
	IHttpCookieCollection Cookies { get; }
	IHttpHeaderCollection Headers { get; }
	Dictionary<string, object> FormData { get; }
	Dictionary<string, object> QueryData { get; }
    }
}
