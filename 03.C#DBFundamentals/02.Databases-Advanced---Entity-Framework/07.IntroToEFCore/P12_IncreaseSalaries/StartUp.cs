using System;
using System.Globalization;
using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace P12_IncreaseSalaries
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                string[] departments = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

                var employees = context.Employees
                    .Where(x => departments.Any(s => s == x.Department.Name))
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToArray();

                using (StreamWriter sw = new StreamWriter("../Employees.txt"))
                {
                    foreach (var e in employees)
                    {
                        e.Salary *= 1.12m;
                        sw.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
