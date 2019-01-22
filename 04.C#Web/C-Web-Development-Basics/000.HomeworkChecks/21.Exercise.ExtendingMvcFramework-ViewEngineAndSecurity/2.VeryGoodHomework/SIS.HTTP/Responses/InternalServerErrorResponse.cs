using SIS.HTTP.Enumerations;

namespace SIS.HTTP.Responses
{
    public class InternalServerErrorResponse : HttpResponse
    {
	public InternalServerErrorResponse() : base(HttpResponseStatusCode.InternalServerError) { }
    }
}
