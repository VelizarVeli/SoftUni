namespace SIS.Framework.Routers
{
    using Common;
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using System.Linq;
    using WebServer.Routing.Contracts;

    public class HttpRouteHandler : IHttpHandler
    {
        public HttpRouteHandler(IHttpHandler controllerHandler, IHttpHandler resourceHandler)
        {
            this.ControllerHandler = controllerHandler;
            this.ResourceHandler = resourceHandler;
        }

        protected IHttpHandler ControllerHandler { get; }

        protected IHttpHandler ResourceHandler { get; }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (this.IsResourceRequest(request.Path))
            {
                return this.ResourceHandler.Handle(request);
            }

            return this.ControllerHandler.Handle(request);
        }

        private bool IsResourceRequest(string requestPath)
        {
            if (requestPath.Contains('.'))
            {
                var requestPathExtension = requestPath.Substring(requestPath.LastIndexOf('.'));
                return Constants.ResourceExtentisons.ToList().Contains(requestPathExtension);
            }

            return false;
        }
    }
}