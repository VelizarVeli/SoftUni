using System;
using System.Collections.Generic;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace SIS.WebServer.Routing.Contracts
{
    public interface IServerRoutingTable
    {
	Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>> Routes { get; }
	void AddRoute(HttpRequestMethod requestMethod, string path, IHttpResponse response);
	bool ContainsRoute(IHttpRequest httpRequest);
    }
}
