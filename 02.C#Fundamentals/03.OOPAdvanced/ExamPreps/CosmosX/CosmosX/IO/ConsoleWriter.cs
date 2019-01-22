using System;
using System.Text;
using CosmosX.IO.Contracts;

namespace CosmosX.IO
{
    public class ConsoleWriter : IWriter
    {
        private readonly StringBuilder sb;

        public ConsoleWriter()
        {
            this.sb = new StringBuilder();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
           // this.sb.AppendLine(output);
        }
    }
}