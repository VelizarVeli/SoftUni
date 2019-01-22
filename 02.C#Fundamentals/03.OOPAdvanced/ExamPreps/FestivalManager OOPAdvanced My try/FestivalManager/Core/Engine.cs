using System;
using System.Linq;
namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IFestivalController festivalCоntroller;
        private readonly ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController,
            ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }
            var report = this.festivalCоntroller.ProduceReport();
            this.writer.WriteLine("Results:");
            this.writer.WriteLine(report);
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split(' ');

            var command = tokens.First();
            var args = tokens.Skip(1).ToArray();

            switch (command)
            {
                case "RegisterSet":
                    {
                        var output = this.festivalCоntroller.RegisterSet(args);
                        return output;
                    }
                case "SignUpPerformer":
                    {
                        var output = this.festivalCоntroller.SignUpPerformer(args);
                        return output;
                    }
                case "RegisterSong":
                    {
                        var output = this.festivalCоntroller.RegisterSong(args);
                        return output;
                    }
                case "AddSongToSet":
                    {
                        var output = this.festivalCоntroller.AddSongToSet(args);
                        return output;
                    }
                case "AddPerformerToSet":
                    {
                        var output = this.festivalCоntroller.AddPerformerToSet(args);
                        return output;
                    }
                case "RepairInstruments":
                    {
                        var output = this.festivalCоntroller.RepairInstruments(args);
                        return output;
                    }
                case "LetsRock":
                    {
                        var output = this.setCоntroller.PerformSets();
                        return output;
                    }
                default:
                    throw new InvalidOperationException("Invalid command!");
            }
        }
    }
}