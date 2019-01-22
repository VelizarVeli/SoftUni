namespace SIS.MVC.Framework.Loggers
{
    using Contracts;
    using System;

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow}] {message}");
        }
    }
}