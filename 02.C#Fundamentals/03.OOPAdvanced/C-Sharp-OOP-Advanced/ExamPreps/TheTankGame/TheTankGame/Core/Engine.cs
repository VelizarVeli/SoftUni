using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TheTankGame.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            while (true)
            {
                List<string> input = this.reader.ReadLine().Split().ToList();

                if (input[0] == "Terminate")
                {
                    //TODO: print whatever is needed
                    break;
                }
                var commandInterpreter = new CommandInterpreter();

                try
                {
                    var result = this.commandInterpreter(input);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }
        }
    }
}