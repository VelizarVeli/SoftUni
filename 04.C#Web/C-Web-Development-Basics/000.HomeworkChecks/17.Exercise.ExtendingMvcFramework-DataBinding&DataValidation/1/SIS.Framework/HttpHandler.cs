namespace SIS.Framework
{
    using HTTP.Enums;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using System.IO;
    using System.Linq;
    using WebServer.Api.Contracts;
    using WebServer.Results;
    using WebServer.Routing;

    public class HttpHandler : IHttpHandlersContext
    {
        private readonly ServerRoutingTable serverRoutingTable;

        public HttpHandler(ServerRoutingTable serverRoutingTable)
        {
            this.serverRoutingTable = serverRoutingTable;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (this.IsResourceRequest(request.Path)) return this.HandleRequestResponse(request.Path);

            if (!this.serverRoutingTable.Routes.ContainsKey(request.RequestMethod) ||
               !this.serverRoutingTable.Routes[request.RequestMethod].ContainsKey(request.Path))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[request.RequestMethod][request.Path].Invoke(request);
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

        private IHttpResponse HandleRequestResponse(string path)
        {
            int indexOfStartOfExtension = path.LastIndexOf('.');
            int indexOfStartOfNameOfResource = path.LastIndexOf('/');

            string requestPathExtension = path.Substring(indexOfStartOfExtension);
            string resourceName = path.Substring(indexOfStartOfNameOfResource);

            string resourcePath = $@"../../../Resources/{requestPathExtension.Substring(1)}{resourceName}";

            if (!File.Exists(resourcePath)) return new HttpResponse(HttpResponseStatusCode.NotFound);

            byte[] fileContent = File.ReadAllBytes(resourcePath);

            return new InlineResourceResult(fileContent, HttpResponseStatusCode.Ok);
        }
    }
}
