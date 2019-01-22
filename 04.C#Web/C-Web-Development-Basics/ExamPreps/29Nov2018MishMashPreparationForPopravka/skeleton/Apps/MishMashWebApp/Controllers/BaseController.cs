using MishMashWebApp.Data;
using SIS.MvcFramework;

namespace MishMashWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new MishMashDbContext();
        }
        public MishMashDbContext Db { get; }
    }
}
