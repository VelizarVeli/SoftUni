using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Headers.Contracts;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
	private readonly Dictionary<string, IHttpHeader> headers;

	public HttpHeaderCollection()
	{
	    headers = new Dictionary<string, IHttpHeader>();
	}

	public void AddHeader(IHttpHeader header)
	{
	    if (header != null)
	    {
		if (!ContainsHeader(header.Key))
		{
		    headers.Add(header.Key, header);
		}
		else SetHeader(header);
	    }
	}

	public bool ContainsHeader(string key)
	{
	    return headers.ContainsKey(key);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
	    return headers.GetEnumerator();
	}

	public IEnumerator<IHttpHeader> GetEnumerator()
	{
	    foreach (var header in headers)
	    {
		yield return header.Value;
	    }
	}

	public IHttpHeader GetHeader(string key)
	{
	    return headers.GetValueOrDefault(key, null);
	}

	public void SetHeader(IHttpHeader header)
	{
	    if (header != null)
	    {
		if (!ContainsHeader(header.Key))
		{
		    AddHeader(header);
		}
		else headers[header.Key] = header;
	    }
	}

	public override string ToString()
	{
	    StringBuilder headersInfo = new StringBuilder();
	    foreach (var header in headers)
	    {
		headersInfo.Append(header.Value.ToString());
		headersInfo.Append(Environment.NewLine);
	    }
	    return headersInfo.ToString();
	}
    }
}
