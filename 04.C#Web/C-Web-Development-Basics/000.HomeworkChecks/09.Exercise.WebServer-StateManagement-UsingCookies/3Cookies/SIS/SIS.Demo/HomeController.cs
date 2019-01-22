using Http.Responses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Results;

namespace SIS.Demo
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>Hello, Word! </h1>";

            return new HtmlResult(content, System.Net.HttpStatusCode.OK);
        }
    }
}
