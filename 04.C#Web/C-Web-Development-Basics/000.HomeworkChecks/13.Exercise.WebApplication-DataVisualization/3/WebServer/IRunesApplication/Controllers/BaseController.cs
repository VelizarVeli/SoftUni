namespace WebServer.IRunesApplication.Controllers
{
    using Infrastructure;
    using Server.Http.Contracts;

    public abstract class BaseController : Controller
    {
        public BaseController(IHttpRequest request)
        {
            this.Request = request;            
        }

        protected IHttpRequest Request { get; private set; }

        protected override string ApplicationDirectory => "IRunesApplication";
    }
}
