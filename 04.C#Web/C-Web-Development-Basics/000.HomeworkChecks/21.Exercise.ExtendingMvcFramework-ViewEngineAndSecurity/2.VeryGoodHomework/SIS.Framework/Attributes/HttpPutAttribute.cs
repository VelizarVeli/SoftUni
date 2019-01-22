using SIS.HTTP.Enumerations;

namespace SIS.Framework.Attributes
{
    public class HttpPutAttribute : HttpMethodAttribute
    {
	public override bool IsValid(HttpRequestMethod requestMethod)
	{
	    if (requestMethod.Equals(HttpRequestMethod.PUT)) return true;
	    return false;
	}
    }
}
