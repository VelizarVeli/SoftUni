namespace Torshia.App
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Logger;
    using SIS.MvcFramework.Services;
    using System;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<IHashService, HashService>();
            collection.AddService<IUserCookieService, UserCookieService>();
            collection.AddService<ILogger>(() => new FileLogger($"log.txt"));
        }

        MvcFrameworkSettings IMvcApplication.Configure()
        {
            return new MvcFrameworkSettings();
        }
    }
}