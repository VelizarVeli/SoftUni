using SIS.HTTP.Common;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Responses
{
    public class RedirectResponse : HttpResponse
    {
	public RedirectResponse(string location) : base(HttpResponseStatusCode.SeeOther)
	{
	    Headers.AddHeader(new HttpHeader(Constants.LocationHeaderKey, location));
	}
    }
}
