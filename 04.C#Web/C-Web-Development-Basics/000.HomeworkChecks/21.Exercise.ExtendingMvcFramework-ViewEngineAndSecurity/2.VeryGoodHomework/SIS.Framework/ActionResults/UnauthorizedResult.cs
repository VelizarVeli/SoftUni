using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Views.Contracts;

namespace SIS.Framework.ActionResults
{
    public class UnauthorizedResult : IUnauthorizedResult
    {
	public UnauthorizedResult(IRenderable view)
	{
	    View = view;
	}

	public IRenderable View { get; set; }

	public string Invoke() => View.Render();
    }
}
