namespace Eventures.Loging.LoggerFactoryExtensions
{
    using Eventures.Data;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class DbLoggerExtensions
    {
        public static ILoggerFactory AddContext(this ILoggerFactory factory, Func<string, LogLevel, bool> filter, ApplicationDbContext dbContext)
        {
            factory.AddProvider(new DbLoggerProvider(filter, dbContext));
            return factory;
        }

        public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel, ApplicationDbContext dbContext)
        {
            return AddContext(factory,  (_, LogLevel) => LogLevel >= minLevel, dbContext);
        }
    }
}
