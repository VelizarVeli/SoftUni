namespace EventWebApp.Logging
{
    using System;
    using Data;
    using Microsoft.Extensions.Logging;

    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> filter;
        private readonly ApplicationDbContext dbContext;

        public DbLoggerProvider(Func<string, LogLevel, bool> filter, ApplicationDbContext dbContext)
        {
            this.filter = filter;
            this.dbContext = dbContext;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(categoryName, this.filter, this.dbContext);
        }

        public void Dispose()
        {

        }
    }
}
