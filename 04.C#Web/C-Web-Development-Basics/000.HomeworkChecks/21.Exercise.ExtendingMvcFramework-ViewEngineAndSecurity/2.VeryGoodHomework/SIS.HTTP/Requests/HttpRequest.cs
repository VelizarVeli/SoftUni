using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Cookies.Contracts;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Sessions.Contracts;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
	public HttpRequest(string requestString)
	{
	    FormData = new Dictionary<string, object>();
	    QueryData = new Dictionary<string, object>();
	    Cookies = new HttpCookieCollection();
	    Headers = new HttpHeaderCollection();
	    ParseRequest(requestString);
	}

	public string Path { get; private set; }
	public string Url { get; private set; }
	public Dictionary<string, object> FormData { get; }
	public Dictionary<string, object> QueryData { get; }
	public IHttpCookieCollection Cookies { get; }
	public IHttpHeaderCollection Headers { get; }
	public HttpRequestMethod Method { get; private set; }
	public IHttpSession Session { get; set; }

	private void ParseRequest(string requestString)
	{
	    string[] requestComponents = requestString
		.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
	    string[] requestLine = requestComponents[0]
		.Split(' ', StringSplitOptions.RemoveEmptyEntries);
	    if (!IsValidRequestLine(requestLine)) throw new BadRequestException();
	    ParseRequestMethod(requestLine[0]);
	    ParseRequestUrl(requestLine[1]);
	    string[] requestHeaders = requestComponents.Skip(1).ToArray();
	    string requestBody = requestComponents.Last();
	    if (!requestBody.Contains(": "))
	    {
		requestHeaders = requestHeaders.Take(requestHeaders.Length - 1).ToArray();
		ParseFormData(requestBody);
	    }
	    ParseHeaders(requestHeaders);
	    ParseCookies(requestHeaders);
	}

	private bool IsValidRequestLine(string[] requestLine)
	{
	    if (requestLine.Length != 3) return false;
	    if (!requestLine[2].Equals(Constants.HttpOneProtocolFragment)) return false;
	    return true;
	}

	private void ParseRequestMethod(string requestMethod)
	{
	    Enum.TryParse(typeof(HttpRequestMethod), requestMethod, true, out object method);
	    if (method == null) throw new BadRequestException();
	    Method = (HttpRequestMethod)method;
	}

	private void ParseRequestUrl(string requestUrl)
	{
	    if (!IsValidRequestUrl(requestUrl, out Match url))
		throw new BadRequestException();
	    Url = url.Value;
	    Path = url.Groups["path"].Value;
	    string requestQuery = url.Groups["query"].Value;
	    ParseQueryData(requestQuery);
	    string requestFragment = url.Groups["fragment"].Value;
	}

	private bool IsValidRequestUrl(string requestUrl, out Match urlComponents)
	{
	    urlComponents = Regex.Match(requestUrl, Constants.UrlPattern);
	    return urlComponents.Success;
	}

	private void ParseRequestParameters(string requestQuery, string requestBody)
	{
	    ParseQueryData(requestQuery);
	    ParseFormData(requestBody);
	}

	private void ParseQueryData(string requestQuery)
	{
	    if (IsValidRequestQuery(requestQuery))
	    {
		var queryParameters = requestQuery.TrimStart('?')
		    .Split('&').Select(p => WebUtility.UrlDecode(p));
		foreach (var queryParameter in queryParameters)
		{
		    string[] queryParameterArgs = queryParameter.Split('=', 2);
		    string queryParameterKey = queryParameterArgs[0];
		    string queryParameterValue = queryParameterArgs[1];
		    QueryData.Add(queryParameterKey, queryParameterValue);
		}
	    }
	}

	private bool IsValidRequestQuery(string requestQuery)
	{
	    if (string.IsNullOrEmpty(requestQuery)) return false;
	    int queryParametersCount = requestQuery
		.Split('=', StringSplitOptions.RemoveEmptyEntries).Count();
	    if (queryParametersCount == 0) return false;
	    return true;
	}

	private void ParseFormData(string requestBody)
	{
	    if (!string.IsNullOrWhiteSpace(requestBody) && requestBody.Contains('='))
	    {
		var bodyParameters = requestBody.Split('&')
		    .Select(p => WebUtility.UrlDecode(p));
		foreach (var bodyParameter in bodyParameters)
		{
		    string[] bodyParameterArgs = bodyParameter.Split('=', 2);
		    string bodyParameterkey = bodyParameterArgs[0];
		    string bodyParameterValue = bodyParameterArgs[1];
		    FormData.Add(bodyParameterkey, bodyParameterValue);
		}
	    }
	}

	private void ParseHeaders(string[] requestHeaders)
	{
	    foreach (var requestHeader in requestHeaders)
	    {
		string[] headerArgs = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);
		if (headerArgs.Length == 2 && headerArgs[0] != Constants.CookieRequestHeaderKey)
		{
		    string headerKey = headerArgs[0];
		    string headerValue = headerArgs[1];
		    IHttpHeader header = new HttpHeader(headerKey, headerValue);
		    Headers.AddHeader(header);
		}
	    }
	    if (Headers.GetHeader(Constants.HostHeaderKey) == null) throw new BadRequestException();
	}

	private void ParseCookies(string[] requestHeaders)
	{
	    string cookieHeader = requestHeaders.SingleOrDefault(h
		=> h.StartsWith(Constants.CookieRequestHeaderKey));
	    if (cookieHeader != null)
	    {
		string[] cookies = cookieHeader
		    .Replace($"{Constants.CookieRequestHeaderKey}: ", string.Empty)
		    .Split("; ", StringSplitOptions.RemoveEmptyEntries)
		    .Distinct().ToArray();
		foreach (var cookie in cookies)
		{
		    string[] cookieAttributes = cookie.Split('=', 2);
		    string cookieName = cookieAttributes[0];
		    string cookieValue = cookieAttributes[1];
		    var httpCookie = new HttpCookie(cookieName, cookieValue);
		    Cookies.AddCookie(httpCookie);
		}
	    }
	}

	public override string ToString()
	{
	    StringBuilder request = new StringBuilder();
	    request.Append($"{Method} {Url} {Constants.HttpOneProtocolFragment}");
	    request.Append(Environment.NewLine);
	    if (Headers.Any()) request.Append(Headers.ToString());
	    if (Cookies.Any())
	    {
		request.Append(Constants.CookieRequestHeaderKey);
		request.Append($": {Cookies.ToString()}");
	    }
	    request.Append(Environment.NewLine);
	    return request.ToString();
	}
    }
}
