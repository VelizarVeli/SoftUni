using SIS.HTTP.Enumerations;

namespace SIS.HTTP.Responses
{
    public class BadRequestResponse : HttpResponse
    {
	public BadRequestResponse(string content) : base(content, HttpResponseStatusCode.BadRequest) { }
    }
}
