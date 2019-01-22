using System.Collections.Generic;

namespace SIS.Framework.Models.Contracts
{
    public interface IViewModel
    {
	IDictionary<string, object> Data { get; set; }
    }
}
