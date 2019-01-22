using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

namespace SIS.WebServer.Api
{
    public interface IHttpHandler
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
