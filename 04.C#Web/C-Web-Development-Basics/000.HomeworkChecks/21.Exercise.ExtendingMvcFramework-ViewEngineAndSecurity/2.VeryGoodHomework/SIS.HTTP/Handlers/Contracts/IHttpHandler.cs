using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace SIS.HTTP.Handlers.Contracts
{
    public interface IHttpHandler
    {
	IHttpResponse Handle(IHttpRequest request);
    }
}
