using SIS.HTTP.Enums;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;

namespace SIS.Demo
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            var result = $@"<h1>Hello World!</h1>
<br /><br />
<h2>If you already have an account you can <a href=""/login"">Login</a></h2>
<h2>or you can <a href=""/register"">Register</a> instead</h2>";
            return new HtmlResult(result, HttpResponseStatusCode.Ok);
        }
    }
}