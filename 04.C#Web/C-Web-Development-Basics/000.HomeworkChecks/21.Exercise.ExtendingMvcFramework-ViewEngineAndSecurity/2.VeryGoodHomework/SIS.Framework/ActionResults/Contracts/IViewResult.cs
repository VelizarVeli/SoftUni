using SIS.Framework.Views.Contracts;

namespace SIS.Framework.ActionResults.Contracts
{
    public interface IViewResult : IActionResult
    {
	IRenderable View { get; set; }
    }
}
