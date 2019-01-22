using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Common;

namespace SIS.Framework.ActionResults
{
    public class NotFoundResult : INotFoundResult
    {
	public NotFoundResult(string resourceType, string resourceName)
	{
	    Message = string.Format(Constants.NotFoundResultMessage, resourceType, resourceName);
	}

	public string Message { get; set; }

	public string Invoke() => Message;
    }
}
