using SIS.MvcFramework;
using TORSHIAWebApp.Data;

namespace TORSHIAWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new TorshiaDbContext();
        }

        protected TorshiaDbContext Db { get; }
    }
}
