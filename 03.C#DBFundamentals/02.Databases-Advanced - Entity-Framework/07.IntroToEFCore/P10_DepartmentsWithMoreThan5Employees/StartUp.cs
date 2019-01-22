using System;
using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace P10_DepartmentsWithMoreThan5Employees
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var departments = context.Departments
                    .Where(x => x.Employees.Count > 5)
                    .OrderBy(x => x.Employees.Count)
                    .ThenBy(x => x.Name)
                    .Select(x => new
                    {
                        DepartmentName = x.Name,
                        ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
                        Employees = x.Employees.Select(s => new
                        {
                            s.FirstName,
                            s.LastName,
                            s.JobTitle
                        })
                        .OrderBy(f=> f.FirstName)
                        .ThenBy(l=>l.LastName)
                    })
                    .ToArray();

                using (StreamWriter sw = new StreamWriter("../Employees.txt"))
                {
                    foreach (var dep in departments)
                    {
                        sw.WriteLine($"{dep.DepartmentName} - {dep.ManagerName}");

                        foreach (var depy in dep.Employees)
                        {
                            sw.WriteLine($"{depy.FirstName} {depy.LastName} - {depy.JobTitle}");
                        }

                        sw.WriteLine("----------");
                    }
                }
            }
        }
    }
}
