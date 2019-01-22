namespace EventWebApp.Logging
{
    using System;
    using Data;
    using Microsoft.Extensions.Logging;

    public static class DbLoggerExtensions
    {
       public static ILoggerFactory AddContext(
           this ILoggerFactory factory,
           ApplicationDbContext dbContext,
           Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new DbLoggerProvider(filter,dbContext));
            return factory;
        }

        public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel,   ApplicationDbContext dbContext)
        {
            return AddContext(
                factory,
                dbContext,
                (_, logLevel) => logLevel >= minLevel);
        }
    }
}
