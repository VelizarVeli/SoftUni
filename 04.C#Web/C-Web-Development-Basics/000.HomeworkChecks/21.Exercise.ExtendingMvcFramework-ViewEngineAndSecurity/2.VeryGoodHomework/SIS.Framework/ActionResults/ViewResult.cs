using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Views.Contracts;

namespace SIS.Framework.ActionResults
{
    public class ViewResult : IViewResult
    {
	public ViewResult(IRenderable view)
	{
	    View = view;
	}

	public IRenderable View { get; set; }

	public string Invoke() => View.Render();
    }
}
