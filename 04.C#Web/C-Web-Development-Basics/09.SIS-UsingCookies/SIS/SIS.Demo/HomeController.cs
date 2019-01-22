using SIS.WebServer.Results;
using System.Net;
using SIS.HTTP.Responses;

namespace SIS.Demo
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>How you doing?</h1>";

            return new HtmlResults(content, HttpStatusCode.OK);
        }
    }
}