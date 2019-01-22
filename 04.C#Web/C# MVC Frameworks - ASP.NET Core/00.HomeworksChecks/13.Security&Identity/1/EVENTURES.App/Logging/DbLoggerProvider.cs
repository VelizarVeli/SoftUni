using EVENTURES.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Logging
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private Func<string, LogLevel, bool> filter;
        private EventureDbContext context;

        public DbLoggerProvider(Func<string, LogLevel, bool> filter, EventureDbContext context)
        {
            this.filter = filter;
            this.context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(categoryName, filter, this.context);
        }
    }
}
