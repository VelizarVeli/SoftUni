namespace SIS.WebServer.Api.Contracts
{
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;

    public interface IHttpHandlersContext
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
