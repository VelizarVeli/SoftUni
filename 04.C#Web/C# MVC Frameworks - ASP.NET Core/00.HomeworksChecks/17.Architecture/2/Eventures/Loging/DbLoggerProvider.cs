using Eventures.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Loging
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private Func<string, LogLevel, bool> filter;
        private ApplicationDbContext dbContext;

        public DbLoggerProvider(Func<string, LogLevel, bool> filter, ApplicationDbContext dbContext)
        {
            this.filter = filter;
            this.dbContext = dbContext;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(categoryName, filter, this.dbContext); 
        } 

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
