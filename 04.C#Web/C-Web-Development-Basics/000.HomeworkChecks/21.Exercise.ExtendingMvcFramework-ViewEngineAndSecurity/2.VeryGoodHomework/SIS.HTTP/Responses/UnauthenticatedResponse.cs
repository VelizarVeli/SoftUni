using SIS.HTTP.Common;
using SIS.HTTP.Enumerations;

namespace SIS.HTTP.Responses
{
    public class UnauthenticatedResponse : HttpResponse
    {
	public UnauthenticatedResponse(string content = Constants.UnauthenticatedMessage)
	    : base(content, HttpResponseStatusCode.Unauthorized) { }
    }
}
