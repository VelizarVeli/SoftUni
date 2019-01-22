using System;

namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(IReader reader,IWriter writer,ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string inputLine = this.reader.ReadLine();
                IList<string> inputParameters = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                string outputResult = this.commandInterpreter.ProcessInput(inputParameters);

                if (inputLine == "Terminate")
                {
                    this.isRunning = false;
                }

                this.writer.WriteLine(outputResult);
            }

            this.writer.Flush();
        }
    }
}