using System;
using System.Linq;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Cookies.Contracts;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.HTTP.Sessions.Contracts;
using SIS.Services;
using SIS.Services.Contracts;

namespace SIS.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
	private readonly IEnumerationService Enumerator;

	public HttpResponse()
	{
	    Content = new byte[0];
	    Cookies = new HttpCookieCollection();
	    Enumerator = new EnumerationService();
	    Headers = new HttpHeaderCollection();
	}

	public HttpResponse(HttpResponseStatusCode statusCode) : this()
	{
	    StatusCode = statusCode;
	}

	public HttpResponse(string content, HttpResponseStatusCode statusCode) : this(statusCode)
	{
	    Content = Encoding.UTF8.GetBytes(content);
	    Headers.AddHeader(new HttpHeader(
		Constants.ContentLengthHeaderKey, Content.Length.ToString()));
	}

	public HttpResponseStatusCode StatusCode { get; set; }
	public IHttpCookieCollection Cookies { get; }
	public IHttpHeaderCollection Headers { get; private set; }
	public IHttpSession Session { get; set; }
	public byte[] Content { get; set; }

	public byte[] GetBytes()
	{
	    return Encoding.UTF8.GetBytes(ToString()).Concat(Content).ToArray();
	}

	public override string ToString()
	{
	    StringBuilder response = new StringBuilder();
	    response.Append(Constants.HttpOneProtocolFragment);
	    string statusText = Enumerator.ToTextOrDefault(StatusCode.GetType(), StatusCode);
	    response.Append($" {statusText}");
	    response.Append(Environment.NewLine);
	    if (Headers.Any()) response.Append(Headers.ToString());
	    if (Cookies.Any())
	    {
		response.Append(Constants.CookieResponseHeaderKey);
		response.Append($": {Cookies.ToString()}");
	    }
	    response.Append(Environment.NewLine);
	    return response.ToString();
	}
    }
}
