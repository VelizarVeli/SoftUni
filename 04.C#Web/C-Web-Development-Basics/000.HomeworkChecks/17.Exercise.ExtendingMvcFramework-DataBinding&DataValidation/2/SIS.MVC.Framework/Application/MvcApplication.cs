namespace SIS.MVC.Framework.Application
{
    using Contracts;
    using Loggers;
    using Loggers.Contracts;
    using Services;
    using Services.Contracts;

    public class MvcApplication : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<IHashService, HashService>();
            collection.AddService<IUserCookieService, UserCookieService>();
            collection.AddService<ILogger, FileLogger>();
            collection.AddService<ILogger, ConsoleLogger>();
        }
    }
}