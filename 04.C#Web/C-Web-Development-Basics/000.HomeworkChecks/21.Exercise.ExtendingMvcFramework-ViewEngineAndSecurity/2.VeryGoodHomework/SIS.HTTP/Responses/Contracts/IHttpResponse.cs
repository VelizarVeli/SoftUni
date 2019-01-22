using SIS.HTTP.Cookies.Contracts;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Sessions.Contracts;

namespace SIS.HTTP.Responses.Contracts
{
    public interface IHttpResponse
    {
	HttpResponseStatusCode StatusCode { get; set; }
	IHttpCookieCollection Cookies { get; }
	IHttpHeaderCollection Headers { get; }
	IHttpSession Session { get; set; }
	byte[] Content { get; set; }
	byte[] GetBytes();
    }
}
