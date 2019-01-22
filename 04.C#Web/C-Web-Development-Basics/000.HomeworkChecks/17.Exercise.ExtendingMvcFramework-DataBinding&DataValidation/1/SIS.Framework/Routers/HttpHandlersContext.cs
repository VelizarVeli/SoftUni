namespace SIS.Framework.Routers
{
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using System.Linq;
    using WebServer.Api.Contracts;

    public class HttpHandlersContext : IHttpHandlersContext
    {
        private readonly IHttpHandler controllerRouter;

        private readonly IHttpHandler resourceRouter;

        public HttpHandlersContext(IHttpHandler controllerRouter, IHttpHandler resourceRouter)
        {
            this.controllerRouter = controllerRouter;
            this.resourceRouter = resourceRouter;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (this.IsResourceRequest(request.Path)) return this.resourceRouter.Handle(request);

            return this.controllerRouter.Handle(request);
        }

        private bool IsResourceRequest(string path)
        {
            if (path.Contains('.'))
            {
                string requestPathExtension = path.Substring(path.LastIndexOf('.'));

                return new string[] { ".css", ".js" }.ToArray().Contains(requestPathExtension);
            }

            return false;
        }
    }
}
