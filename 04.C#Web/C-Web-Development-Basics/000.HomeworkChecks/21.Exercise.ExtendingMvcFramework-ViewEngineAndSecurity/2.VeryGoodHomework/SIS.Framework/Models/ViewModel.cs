using System.Collections.Generic;
using SIS.Framework.Models.Contracts;

namespace SIS.Framework.Models
{
    public class ViewModel : IViewModel
    {
	public ViewModel()
	{
	    Data = new Dictionary<string, object>();
	}

	public IDictionary<string, object> Data { get; set; }

	public object this[string key]
	{
	    get => Data[key];
	    set => Data[key] = value;
	}
    }
}
