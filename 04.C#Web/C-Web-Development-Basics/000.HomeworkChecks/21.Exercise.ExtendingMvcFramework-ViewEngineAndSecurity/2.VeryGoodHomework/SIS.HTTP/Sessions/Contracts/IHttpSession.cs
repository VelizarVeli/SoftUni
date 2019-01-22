using System.Collections.Generic;

namespace SIS.HTTP.Sessions.Contracts
{
    public interface IHttpSession : IEnumerable<object>
    {
	string Id { get; }
	void AddParameter(string name, object parameter);
	void ClearParameters();
	bool ContainsParameter(string name);
	object GetParameter(string name);
	void SetParameter(string name, object value);
    }
}
