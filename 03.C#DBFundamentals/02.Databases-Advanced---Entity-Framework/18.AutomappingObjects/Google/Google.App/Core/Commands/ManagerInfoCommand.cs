using System.Text;
using Google.App.Core.Contracts;

namespace Google.App.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly IManagerController managerController;

        public ManagerInfoCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int employeeId = int.Parse(args[0]);

            var managerDto = this.managerController.GetManagerInfo(employeeId);

            sb.AppendLine(
                $"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.EmployeesCount}");

            foreach (var employee in managerDto.EmployeeDtos)
            {
                sb.AppendLine($"- {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
