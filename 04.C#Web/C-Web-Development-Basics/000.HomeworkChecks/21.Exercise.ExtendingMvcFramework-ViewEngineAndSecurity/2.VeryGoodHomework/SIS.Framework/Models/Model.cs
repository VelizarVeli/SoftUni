using SIS.Framework.Models.Contracts;

namespace SIS.Framework.Models
{
    public class Model : IModel
    {
	private bool? isValid;

	public bool? IsValid
	{
	    get => isValid;
	    set => isValid = isValid ?? value;
	}
    }
}
