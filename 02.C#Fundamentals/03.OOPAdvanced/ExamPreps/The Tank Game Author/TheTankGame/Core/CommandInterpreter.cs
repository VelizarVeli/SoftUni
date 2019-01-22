namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;

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

            string result = (string)this.tankManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name.Contains(command))
                .Invoke(this.tankManager, new object[] { inputParameters });


            //switch (command)
            //{
            //    //Rename to AddVehicle
            //    case "Vehicle":
            //        result = this.tankManager.AddVehicle(inputParameters);
            //        break;
            //    //Rename to AddPart
            //    case "Part":
            //        result = this.tankManager.AddPart(inputParameters);
            //        break;
            //    case "Inspect":
            //        result = this.tankManager.Inspect(inputParameters);
            //        break;
            //    case "Battle":
            //        result = this.tankManager.Battle(inputParameters);
            //        break;
            //    case "Terminate":
            //        result = this.tankManager.Terminate(inputParameters);
            //        break;
            //}

            return result;
        }
    }
}