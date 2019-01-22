using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace SIS.WebServer.Api
{
    public interface IHttpHandlingContext
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}