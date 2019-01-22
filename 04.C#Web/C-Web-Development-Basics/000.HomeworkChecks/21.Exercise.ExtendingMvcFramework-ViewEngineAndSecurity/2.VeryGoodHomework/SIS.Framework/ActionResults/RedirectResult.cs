using SIS.Framework.ActionResults.Contracts;

namespace SIS.Framework.ActionResults
{
    public class RedirectResult : IRedirectResult
    {
	public RedirectResult(string redirectUrl)
	{
	    RedirectUrl = redirectUrl;
	}

	public string RedirectUrl { get; }

	public string Invoke() => RedirectUrl;
    }
}
