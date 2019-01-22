using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Contracts;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SIS.Framework.Routers
{
    public class ResourceRouter : IHttpHandler
    {
        private const string RelativePath = "Resources";

        public IHttpResponse Handle(IHttpRequest request)
        {
            return GetResource(request.Path);
        }

        private IHttpResponse GetResource(string path)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;

            char separator = (char)47;

            var parts = codeBase.Remove(0, 8)
                .Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .Skip(4)
                .Reverse();

            string rootPath = string.Join("\\", parts);

            path = path.Trim('/');
            var file = path.Split('/').Last();

            var fileExtension = Path.GetExtension(path).Substring(1);

            var resourcePath = $"{rootPath}\\{RelativePath}\\{fileExtension}\\{file}";

            var resource = File.ReadAllText(resourcePath);

            var resourceBytes = Encoding.UTF8.GetBytes(resource);

            return new InlineResourceResult(resourceBytes, HttpResponseStatusCode.Ok);
        }
    }
}
