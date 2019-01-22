namespace SIS.Framework.Routers
{
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using HTTP.Enums;
    using HTTP.Responses;
    using WebServer.Results;
    using System.IO;
    using WebServer.Api.Contracts;

    public class ResourceRouter : IHttpHandler
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            string path = request.Path;

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
