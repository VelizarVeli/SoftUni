namespace Eventures.Loging
{
    using Eventures.Data;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DbLogger : ILogger
    {
        private string categoryName;
        Func<string, LogLevel, bool> filter;
        private ApplicationDbContext context;

        public DbLogger(string categoryName, Func<string, LogLevel, bool> filter, ApplicationDbContext dbContext)
        {
            this.categoryName = categoryName;
            this.filter = filter;
            this.context = dbContext;
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
            //if (logLevel == LogLevel.Error)
            //{
            //    this.context.Logs.Add(new CustomLog());
            //    this.context.SaveChanges();
            //}
        }
    }
}
