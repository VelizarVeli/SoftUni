using System;
using Logger.Models.Contracts;

namespace Logger.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public string Message { get; }

        public DateTime DateTime { get; }

        public ErrorLevel Level { get; }
    }
}
