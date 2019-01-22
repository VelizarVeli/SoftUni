using SIS.HTTP.Headers.Contracts;

namespace SIS.HTTP.Headers
{
    public class HttpHeader : IHttpHeader
    {
	public HttpHeader(string key, string value)
	{
	    Key = key;
	    Value = value;
	}

	public virtual string Key { get; }
	public string Value { get; }

	public override string ToString()
	{
	    return $"{Key}: {Value}";
	}
    }
}
