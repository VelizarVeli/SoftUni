using System;
using System.Collections.Generic;
using System.Linq;
using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string inputLine = this.reader.ReadLine();
                IList<string> inputParameters = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string outputResult = this.commandParser.Parse(inputParameters);

                if (inputLine == "Exit")
                {
                    this.isRunning = false;
                }

                this.writer.WriteLine(outputResult);
            }
        }
    }
}