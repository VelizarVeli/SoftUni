using System;
using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace P04_EmployeesWithSalaryOver50000
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var emplSalary = context.Employees
                    .Where(emp => emp.Salary > 50000)
                    .OrderBy(n => n.FirstName);

                using (StreamWriter sw = new StreamWriter("../Employees.txt"))
                {
                    foreach (var employee in emplSalary)
                    {
                        sw.WriteLine(employee.FirstName);
                    }
                }
            }
        }
    }
}
