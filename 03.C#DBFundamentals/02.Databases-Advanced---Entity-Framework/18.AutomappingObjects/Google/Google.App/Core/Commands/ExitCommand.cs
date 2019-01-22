using System;
using System.Threading;
using Google.App.Core.Contracts;

namespace Google.App.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine($"Your life will start after {i} seconds");
                Thread.Sleep(1000);
            }

            Environment.Exit(0);

            return null;
        }
    }
}
