using System;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies.Contracts;

namespace SIS.HTTP.Cookies
{
    public class HttpCookie : IHttpCookie
    {
	public HttpCookie(string name, string value,
	    int lifetimeInDays = Constants.CookieDefaultLifetimeInDays,
	    int maxAge = Constants.CookieDefaultMaxAgeInSeconds,
	    string path = Constants.CookieDefaultPath,
	    bool isHttpOnly = true)
	{
	    Expires = DateTime.UtcNow.AddDays(lifetimeInDays);
	    IsHttpOnly = isHttpOnly;
	    MaxAge = maxAge;
	    Name = name;
	    Path = path;
	    Value = value;
	}

	public DateTime Expires { get; }
	public bool IsHttpOnly { get; }
	public int MaxAge { get; }
	public string Name { get; }
	public string Path { get; }
	public string Value { get; }

	public override string ToString()
	{
	    StringBuilder cookieInfo = new StringBuilder();
	    cookieInfo.Append($"{Name}={Value}");
	    cookieInfo.Append($"; {Constants.ExpiresCookieKey}={Expires:R}");
	    cookieInfo.Append($"; {Constants.MaxAgeCookieKey}={MaxAge}");
	    cookieInfo.Append($"; {Constants.PathCookieKey}={Path}");
	    if (IsHttpOnly) cookieInfo.Append($"; {Constants.HttpOnlyCookieKey}");
	    return cookieInfo.ToString();
	}
    }
}
