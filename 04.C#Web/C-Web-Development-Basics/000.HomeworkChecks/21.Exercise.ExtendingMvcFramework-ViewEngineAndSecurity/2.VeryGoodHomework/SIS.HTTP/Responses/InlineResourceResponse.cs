using SIS.HTTP.Common;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Responses
{
    public class InlineResourceResponse : HttpResponse
    {
	public InlineResourceResponse(byte[] content) : base(HttpResponseStatusCode.OK)
	{
	    Content = content;
	    Headers.AddHeader(new HttpHeader(Constants.ContentDispositionHeaderKey, "inline"));
	    Headers.AddHeader(new HttpHeader(Constants.ContentLengthHeaderKey, Content.Length.ToString()));
	}
    }
}
