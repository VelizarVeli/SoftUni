using PandaWebApp.Data;

namespace PandaWebApp.Controllers
{
    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new PandaDbContext();
        }

        public PandaDbContext Db { get; }
    }
}
