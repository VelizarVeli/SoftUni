using System;
using System.Collections.Generic;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Routing.Contracts;

namespace SIS.WebServer.Routing
{
    public class ServerRoutingTable : IServerRoutingTable
    {
	public ServerRoutingTable()
	{
	    Routes = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>
	    {
		[HttpRequestMethod.GET] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
		[HttpRequestMethod.POST] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
		[HttpRequestMethod.PUT] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
		[HttpRequestMethod.DELETE] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
	    };
	}

	public Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>> Routes { get; }

	public void AddRoute(HttpRequestMethod requestMethod, string requestPath, IHttpResponse response)
	{
	    Routes[requestMethod][requestPath] = request => response;
	}

	public bool ContainsRoute(IHttpRequest request)
	{
	    if (!Routes.ContainsKey(request.Method)) return false;
	    if (!Routes[request.Method].ContainsKey(request.Path)) return false;
	    return true;
	}
    }
}
