namespace SIS.Framework.Api
{
    using HTTP.Enums;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using WebServer.Routing;
    using WebServer.Routing.Contracts;

    public class HttpHandler : IHttpHandler
    {
        private readonly ServerRoutingTable routingTable;

        public HttpHandler(ServerRoutingTable routingTable)
        {
            this.routingTable = routingTable;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (!this.routingTable.Routes.ContainsKey(request.RequestMethod)
                || !this.routingTable.Routes[request.RequestMethod].ContainsKey(request.Path.ToLower()))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.routingTable.Routes[request.RequestMethod][request.Path].Invoke(request);
        }
    }
}