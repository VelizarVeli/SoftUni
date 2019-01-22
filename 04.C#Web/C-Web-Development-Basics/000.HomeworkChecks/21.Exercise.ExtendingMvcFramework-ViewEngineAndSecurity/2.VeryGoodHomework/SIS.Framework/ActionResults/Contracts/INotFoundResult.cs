namespace SIS.Framework.ActionResults.Contracts
{
    public interface INotFoundResult : IActionResult
    {
	string Message { get; }
    }
}
