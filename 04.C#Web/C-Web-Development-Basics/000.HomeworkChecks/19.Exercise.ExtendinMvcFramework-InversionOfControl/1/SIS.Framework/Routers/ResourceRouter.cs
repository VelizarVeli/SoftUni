namespace SIS.Framework.Routers
{
    using HTTP.Enums;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using System.IO;
    using WebServer.Common;
    using WebServer.Results;
    using WebServer.Routing.Contracts;

    public class ResourceRouter : IHttpHandler
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var requestPath = request.Path;
            var requestPathExtension = requestPath.Substring(requestPath.LastIndexOf('.'));
            var resourceName = requestPath.Substring(requestPath.LastIndexOf('/'));
            var resourcePath = Constants.FolderResourcesRelativePath + requestPathExtension.Substring(1) + resourceName;
            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);

            return new InlineResourceResult(fileContent, HttpResponseStatusCode.Ok);
        }
    }
}