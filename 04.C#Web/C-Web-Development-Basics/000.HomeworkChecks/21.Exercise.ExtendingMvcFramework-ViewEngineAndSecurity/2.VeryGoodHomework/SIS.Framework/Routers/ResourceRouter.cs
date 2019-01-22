using System.IO;
using System.Text.RegularExpressions;
using SIS.Framework.Common;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Routing.Contracts;

namespace SIS.Framework.Routers
{
    public class ResourceRouter : IResourceRouter
    {
	public IHttpResponse Handle(IHttpRequest request)
	{
	    var resourceInfo = Regex.Match(request.Path, Constants.ResourcePattern, RegexOptions.IgnoreCase);
	    string resourceName = resourceInfo.Groups["fileName"].Value;
	    string resourceType = resourceInfo.Groups["fileType"].Value;
	    string resourceFilePath = MvcContext.Get.AppPath
		+ Constants.FolderSeparator + MvcContext.Get.ResourcesFolderName
		+ Constants.FolderSeparator + resourceType
		+ Constants.FolderSeparator + resourceName;
	    if (File.Exists(resourceFilePath))
	    {
		byte[] content = File.ReadAllBytes(resourceFilePath);
		return new InlineResourceResponse(content);
	    }
	    else return new NotFoundResponse(string.Format(
		Constants.NotFoundResultMessage, typeof(File).Name, resourceName));
	}
    }
}
