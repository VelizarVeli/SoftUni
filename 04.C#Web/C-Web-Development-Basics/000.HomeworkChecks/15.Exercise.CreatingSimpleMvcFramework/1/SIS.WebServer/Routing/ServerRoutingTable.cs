namespace SIS.WebServer.Routing
{
    using System;
    using System.Collections.Generic;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using SIS.WebServer.Api;

    public class ServerRoutingTable : IHttpHandler
    {
        public ServerRoutingTable()
        {
            this.Routes = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>()
            {
                [HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
            };
        }

        public Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>> Routes { get; set; }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (!this.Routes.ContainsKey(request.RequestMethod)
                || this.Routes[request.RequestMethod].ContainsKey(request.Path))
            {
                return null;
            }
            return this.Routes[request.RequestMethod][request.Path].Invoke(request);
        }
    }
}