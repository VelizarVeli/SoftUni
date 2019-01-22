namespace IRunesApp.Controllers
{
    using Data;
    using SIS.MVC.Framework.Controllers;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new RunesDbContext();
        }

        protected RunesDbContext Db { get; }
    }
}