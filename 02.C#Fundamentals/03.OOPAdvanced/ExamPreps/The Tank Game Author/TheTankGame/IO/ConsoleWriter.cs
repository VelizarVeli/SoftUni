namespace TheTankGame.IO
{
    using System;
    using System.Text;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        private readonly StringBuilder sb;

        public ConsoleWriter()
        {
            this.sb = new StringBuilder();
        }

        public void WriteLine(string output)
        {
            this.sb.AppendLine(output);
        }

        public void Flush()
        {
            Console.WriteLine(this.sb.ToString().TrimEnd());
        }
    }
}