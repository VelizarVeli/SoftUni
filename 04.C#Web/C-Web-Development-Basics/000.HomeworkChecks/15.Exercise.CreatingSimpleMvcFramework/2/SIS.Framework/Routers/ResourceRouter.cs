namespace SIS.Framework.Routers
{
    using System.IO;
    using HTTP.Enums;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using WebServer.Api;
    using WebServer.Results;

    public class ResourceRouter : IHttpHandler
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var startNameResourceIndex = request.Path.LastIndexOf("/");
            var requestPathExtension = request.Path.Substring(request.Path.LastIndexOf("."));

            var resourceName = request.Path.Substring(startNameResourceIndex);

            var resourcePath = $"../../../Resources/{requestPathExtension.Substring(1)}{resourceName}";

            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);

            return new InlineResourceResult(fileContent, HttpResponseStatusCode.Ok);
        }
    }
}