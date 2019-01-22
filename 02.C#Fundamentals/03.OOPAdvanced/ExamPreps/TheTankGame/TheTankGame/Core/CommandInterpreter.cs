namespace TheTankGame.Core
{
    using System.Collections.Generic;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters.RemoveAt(0);

            string result = string.Empty;

            switch (command)
            {
                case "Vehicle":
                    result = this.tankManager.AddVehicle(inputParameters);
                    break;
                case "Part":
                    result = this.tankManager.AddVehicle(inputParameters);
                    break;
                case "Inspect":
                    result = this.tankManager.Inspect(inputParameters);
                    break;
                case "Battle":
                    result = this.tankManager.Battle(inputParameters);
                    break;
                case "Terminate":
                    result = this.tankManager.Terminate(inputParameters);
                    break;
            }

            return result;
        }
    }
}