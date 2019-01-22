using System.IO;
using P02_DatabaseFirst.Data;
using System.Linq;

namespace P05_EmployeesFromResearchAndDevelopment
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var emplfromDepartment = context.Employees
                    .Where(emp => emp.Department.Name == "Research and Development")
                    .OrderBy(n => n.Salary)
                    .ThenByDescending(n => n.FirstName);

                using (StreamWriter sw = new StreamWriter("../Employees.txt"))
                {
                    foreach (var employee in emplfromDepartment)
                    {
                        sw.WriteLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:f2}");
                    }
                }
            }
        }
    }
}
