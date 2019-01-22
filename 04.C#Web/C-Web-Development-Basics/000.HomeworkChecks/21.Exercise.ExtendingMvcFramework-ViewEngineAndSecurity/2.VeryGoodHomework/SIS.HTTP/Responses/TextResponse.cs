using SIS.HTTP.Common;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Responses
{
    public class TextResponse : HttpResponse
    {
	public TextResponse(string content, HttpResponseStatusCode statusCode = HttpResponseStatusCode.OK)
	    : base(content, statusCode)
	{
	    Headers.AddHeader(new HttpHeader(Constants.ContentTypeHeaderKey, Constants.ContentTypeTextHeaderValue));
	}
    }
}
