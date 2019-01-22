using System;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace P09_Employee147
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employee147 = context.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                        Projects = e.EmployeesProjects
                        .Select(ep => ep.Project.Name)
                        .OrderBy(p => p)
                        .ToList()
                    }).First();

                Console.WriteLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}{Environment.NewLine}" +
                                  $"{string.Join(Environment.NewLine, employee147.Projects)}");
            }
        }
    }
}
