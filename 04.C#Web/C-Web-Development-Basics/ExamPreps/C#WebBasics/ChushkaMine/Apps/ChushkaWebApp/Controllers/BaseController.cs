using ChushkaWebApp.Data;
using SIS.MvcFramework;

namespace ChushkaWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new ChushkaDbContext();
        }

        protected ChushkaDbContext Db { get; }
    }
}
