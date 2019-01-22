namespace EventWebApp.Logging
{
    using System;
    using Data;
    using Data.Models;
    using Microsoft.Extensions.Logging;

    public class DbLogger : ILogger
    {
        private readonly string categoryName;
        private readonly Func<string, LogLevel, bool> filter;
        private readonly ApplicationDbContext dbContext;
        private bool selfException = false;

        public DbLogger(string categoryName, Func<string, LogLevel, bool> filter, ApplicationDbContext dbContext)
        {
            this.categoryName = categoryName;
            this.filter = filter;
            this.dbContext = dbContext;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!this.IsEnabled(logLevel))
            {
                return;
            }

            if (this.selfException)
            {
                this.selfException = false;
                return;
            }
            this.selfException = true;
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (exception != null)
            {
                message += "\n" + exception.ToString();
            }

            try
            {
                this.dbContext.Logs.Add(new CustomLog()
                {
                    Message = message,
                    EventId = eventId.Id,
                    CreatedOn = DateTime.UtcNow,
                    LogLevel = logLevel.ToString()
                });
                this.dbContext.SaveChanges();
                this.selfException = false;
            }
            catch (Exception ex)
            {
                var test = ex;
            }

        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return (this.filter == null || this.filter(this.categoryName, logLevel));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
