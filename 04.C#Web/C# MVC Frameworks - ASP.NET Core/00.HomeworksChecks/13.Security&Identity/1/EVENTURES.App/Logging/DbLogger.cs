using EVENTURES.Data;
using EVENTURES.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Logging
{
    public class DbLogger : ILogger
    {
        private string categoryName;
        private Func<string, LogLevel, bool> filter;
        private EventureDbContext context;

        public DbLogger(string categoryName, Func<string, LogLevel, bool> filter, EventureDbContext context)
        {
            this.categoryName = categoryName;
            this.filter = filter;
            this.context = context;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (logLevel == LogLevel.Error)
            {
                //this.context.Logs.Add(new CustomLog());
                //this.context.SaveChanges();
            }
        }
    }
}
