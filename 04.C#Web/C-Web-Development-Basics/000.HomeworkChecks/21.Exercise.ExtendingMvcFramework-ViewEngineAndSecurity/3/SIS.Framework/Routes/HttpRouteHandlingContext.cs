using SIS.HTTP.Common;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Api;
using System;
using System.Linq;

namespace SIS.Framework.Routes
{
    public class HttpRouteHandlingContext : IHttpHandlingContext
    {
        public HttpRouteHandlingContext(
            IHttpHandler controllerHandler,
            IHttpHandler resourceHandler)
        {
            this.ControllerHandler = controllerHandler;
            this.ResourceHandler = resourceHandler;
        }

        protected IHttpHandler ControllerHandler { get; }

        protected IHttpHandler ResourceHandler { get; }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (this.IsResourceRequest(request))
            {
                return this.ResourceHandler.Handle(request);
            }

            return this.ControllerHandler.Handle(request);
        }

        private bool IsResourceRequest(IHttpRequest httpRequest)
        {
            var requestPath = httpRequest.Path;
            if (requestPath.Contains('.'))
            {
                var requestPathExtension = requestPath.Substring(requestPath.LastIndexOf('.'));
                return GlobalConstans.ResourceExtensions.Contains(requestPathExtension);
            }
            return false;
        }
    }
}