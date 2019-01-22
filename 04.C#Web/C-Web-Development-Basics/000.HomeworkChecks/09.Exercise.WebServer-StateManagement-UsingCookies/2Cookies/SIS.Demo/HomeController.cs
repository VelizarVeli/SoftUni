using SIS.Http.Enum;
using SIS.Http.Responses.Contracts;
using SIS.WebServer.Results;

namespace SIS.Demo
{
    class HomeController
    {
        public IHttpResponse index()
        {
            string content = "<h1>Ola, Mundo</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }

    }
}
