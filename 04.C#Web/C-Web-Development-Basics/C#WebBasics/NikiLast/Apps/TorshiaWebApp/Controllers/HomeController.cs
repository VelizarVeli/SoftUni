using SIS.HTTP.Responses;

namespace TorshiaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View();
        }
    }

}
