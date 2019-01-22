using SIS.HTTP.Enumerations;

namespace SIS.Framework.Attributes
{
    public class HttpDeleteAttribute : HttpMethodAttribute
    {
	public override bool IsValid(HttpRequestMethod requestMethod)
	{
	    if (requestMethod.Equals(HttpRequestMethod.DELETE)) return true;
	    return false;
	}
    }
}
