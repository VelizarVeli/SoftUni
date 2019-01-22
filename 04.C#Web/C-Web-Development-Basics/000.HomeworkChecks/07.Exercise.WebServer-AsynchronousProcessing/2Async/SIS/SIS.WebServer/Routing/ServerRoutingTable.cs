using System;
using System.Collections.Generic;
using SIS.Http.Enum;
using SIS.Http.Requests.Contracts;
using SIS.Http.Responses.Contracts;

namespace SIS.WebServer.Routing
{
    public class ServerRoutingTable
    {
        public ServerRoutingTable()
        {
            this.Routs = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>
            {
                [HttpRequestMethod.GET] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.POST] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.PUT] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.DELETE] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
            };
        }

        public Dictionary<
            HttpRequestMethod, 
            Dictionary<
                string, 
                Func<
                    IHttpRequest, 
                    IHttpResponse>>>Routs { get; set; }


    }
}