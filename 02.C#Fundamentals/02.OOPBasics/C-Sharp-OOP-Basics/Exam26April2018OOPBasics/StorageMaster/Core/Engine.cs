
using System;
using System.Linq;
using StorageMaster.Core.IO.Contracts;

namespace StorageMaster.Core
{
   public class Engine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly StorageMaster storageMaster;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string command = this.reader.ReadLine();
                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine("Error: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("Invalid Operation: " + e.Message);
                }

                if (this.storageMaster.IsGameOver() || this.isRunning == false)
                {
                    this.writer.WriteLine("Final stats:");
                    this.writer.WriteLine(this.storageMaster.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            switch (commandName)
            {
                case "JoinParty":
                    output = this.storageMaster.JoinParty(args);
                    break;
                case "AddItemToPool":
                    output = this.storageMaster.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    output = this.storageMaster.PickUpItem(args);
                    break;
                case "UseItem":
                    output = this.storageMaster.UseItem(args);
                    break;
                case "GiveCharacterItem":
                    output = this.storageMaster.GiveCharacterItem(args);
                    break;
                case "UseItemOn":
                    output = this.storageMaster.UseItemOn(args);
                    break;
                case "GetStats":
                    output = this.storageMaster.GetStats();
                    break;
                case "Attack":
                    output = this.storageMaster.Attack(args);
                    break;
                case "Heal":
                    output = this.storageMaster.Heal(args);
                    break;
                case "EndTurn":
                    output = this.storageMaster.EndTurn(args);
                    break;
            }

            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}
