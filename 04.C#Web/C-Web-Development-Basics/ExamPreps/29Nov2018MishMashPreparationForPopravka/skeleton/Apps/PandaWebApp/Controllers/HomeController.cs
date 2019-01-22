namespace PandaWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View();
        }
    }
}
