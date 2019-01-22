using System;
using System.Text;
using Google.App.Core.Contracts;

namespace Google.App.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeePersonalInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int id = int.Parse(args[0]);

            var employeeDto = this.employeeController.GetEmployeePersonalInfo(id);

            sb.AppendLine($"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}");
            sb.AppendLine($"Birthday: {employeeDto.Birthday.Value.ToString("dd-MM-yyyy")}");
            sb.AppendLine($"Address: {employeeDto.Address}");
            return sb.ToString().TrimEnd();
        }
    }
}
