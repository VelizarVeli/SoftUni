using SIS.Framework.Views.Contracts;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
	private readonly string content;

	public View(string content)
	{
	    this.content = content;
	}

	public string Render() => content;
    }
}
