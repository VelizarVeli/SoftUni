using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using SIS.Http.Responses.Contracts;
using SIS.WebServer.Results;

namespace SIS.Demo2
{
    class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>Hello, World!</h1>";


            return new HtmlResult(content, HttpStatusCode.OK);
        }

    }
}
