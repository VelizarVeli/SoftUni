using EVENTURES.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Logging
{
    public static class LoggerFactoryExtensions
    {

        public static ILoggerFactory AddContext(this ILoggerFactory factory, EventureDbContext dbContext, Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new DbLoggerProvider(filter, dbContext));
            return factory;
        }

        public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel, EventureDbContext context)
        {
            return AddContext(
                factory,
                context,
                (_, logLevel) => logLevel >= minLevel);
        }

    }
}
