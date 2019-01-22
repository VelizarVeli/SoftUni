using MusakaWebApp.Data;
using SIS.MvcFramework;

namespace MusakaWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new ApplicationDbContext();
        }

        public ApplicationDbContext Db { get; }
    }
}
