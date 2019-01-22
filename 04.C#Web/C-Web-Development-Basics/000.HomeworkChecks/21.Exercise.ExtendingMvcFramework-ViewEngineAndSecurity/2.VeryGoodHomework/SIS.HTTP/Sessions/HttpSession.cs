using System;
using System.Collections;
using System.Collections.Generic;
using SIS.HTTP.Sessions.Contracts;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
	private readonly Dictionary<string, object> parameters;

	public HttpSession()
	{
	    Id = Guid.NewGuid().ToString();
	    parameters = new Dictionary<string, object>();
	}

	public HttpSession(string id) : this()
	{
	    Id = id;
	}

	public string Id { get; }

	public void AddParameter(string name, object parameter)
	{
	    if (parameter != null && !ContainsParameter(name))
		parameters.Add(name, parameter);
	}

	public void ClearParameters()
	{
	    parameters.Clear();
	}

	public bool ContainsParameter(string name)
	{
	    return parameters.ContainsKey(name);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
	    return parameters.GetEnumerator();
	}

	public IEnumerator<object> GetEnumerator()
	{
	    foreach (var parameter in parameters)
	    {
		yield return parameter.Value;
	    }
	}

	public object GetParameter(string name)
	{
	    object parameter = parameters.GetValueOrDefault(name, null);
	    return parameter;
	}

	public void SetParameter(string name, object value)
	{
	    if (!parameters.ContainsKey(name))
		AddParameter(name, value);
	    parameters[name] = value;
	}
    }
}
