namespace SIS.Framework.ActionResults.Contracts
{
    public interface IRedirectResult : IActionResult
    {
	string RedirectUrl { get; }
    }
}
