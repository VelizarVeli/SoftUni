namespace Eventures.WebApp.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        protected BaseController(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public ApplicationDbContext Context { get; }
    }
}