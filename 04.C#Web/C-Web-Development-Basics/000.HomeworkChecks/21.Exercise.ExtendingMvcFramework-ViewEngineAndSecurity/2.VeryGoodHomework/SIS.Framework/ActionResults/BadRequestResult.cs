using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Common;

namespace SIS.Framework.ActionResults
{
    public class BadRequestResult : IBadRequestResult
    {
	public BadRequestResult(string reason)
	{
	    Message = string.Format(Constants.BadRequestResultMessage, reason);
	}

	public string Message { get; }

	public string Invoke() => Message;
    }
}
