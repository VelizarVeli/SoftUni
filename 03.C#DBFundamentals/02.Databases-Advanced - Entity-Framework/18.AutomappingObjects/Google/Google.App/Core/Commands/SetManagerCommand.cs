namespace Google.App.Core.Contracts
{
    public class SetManagerCommand : ICommand
    {
        private readonly IManagerController managerController;

        public SetManagerCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            this.managerController.SetManager(employeeId, managerId);

            return "Command is executed successfully.";
        }
    }
}
