using SIS.HTTP.Common;
using SIS.HTTP.Enumerations;

namespace SIS.HTTP.Responses
{
    public class NotFoundResponse : HttpResponse
    {
	public NotFoundResponse(string content = Constants.NotFoundMessage)
	    : base(content, HttpResponseStatusCode.NotFound) { }
    }
}
