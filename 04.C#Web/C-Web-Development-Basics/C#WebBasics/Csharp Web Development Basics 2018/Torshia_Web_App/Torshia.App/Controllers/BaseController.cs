namespace Torshia.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Logger;
    using SIS.MvcFramework.Services;
    using System;
    using Torshia.App.Data;

    public class BaseController : Controller
    {
        protected const string AuthenticationCookieKey = "-auth.torshia";

        protected TorshiaDbContext DbContext;

        protected HashService hashService;

        protected BaseController()
        {
            this.hashService = new HashService(new ConsoleLogger());
            this.DbContext = new TorshiaDbContext();
        }
    }
}