using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Cookies.Contracts;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
	private readonly Dictionary<string, IHttpCookie> cookies;

	public HttpCookieCollection()
	{
	    cookies = new Dictionary<string, IHttpCookie>();
	}

	public void AddCookie(IHttpCookie cookie)
	{
	    if (cookie != null)
	    {
		if (!ContainsCookie(cookie.Name))
		{
		    cookies.Add(cookie.Name, cookie);
		}
	    }
	}

	public bool ContainsCookie(string name)
	{
	    return cookies.ContainsKey(name);
	}

	public IHttpCookie GetCookie(string name)
	{
	    return cookies.GetValueOrDefault(name, null);
	}

	public void SetCookie(IHttpCookie cookie)
	{
	    if (cookie != null)
	    {
		cookies[cookie.Name] = cookie;
	    }
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
	    return cookies.GetEnumerator();
	}

	public IEnumerator<IHttpCookie> GetEnumerator()
	{
	    foreach (var cookie in cookies)
	    {
		yield return cookie.Value;
	    }
	}

	public override string ToString()
	{
	    StringBuilder cookiesInfo = new StringBuilder();
	    cookiesInfo.Append(string.Join("; ", cookies.Values));
	    cookiesInfo.Append(Environment.NewLine);
	    return cookiesInfo.ToString();
	}
    }
}
