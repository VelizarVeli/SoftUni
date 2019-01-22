namespace SIS.Framework.ActionResults.Contracts
{
    public interface IBadRequestResult : IActionResult
    {
	string Message { get; }
    }
}
