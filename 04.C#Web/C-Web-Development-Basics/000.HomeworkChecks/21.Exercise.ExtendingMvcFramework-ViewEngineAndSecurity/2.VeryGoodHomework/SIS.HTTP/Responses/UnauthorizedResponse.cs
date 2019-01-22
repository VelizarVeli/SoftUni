using SIS.HTTP.Common;
using SIS.HTTP.Enumerations;

namespace SIS.HTTP.Responses
{
    public class UnauthorizedResponse : HttpResponse
    {
	public UnauthorizedResponse(string content = Constants.UnauthorizedMessage)
	    : base(content, HttpResponseStatusCode.Forbidden) { }
    }
}
