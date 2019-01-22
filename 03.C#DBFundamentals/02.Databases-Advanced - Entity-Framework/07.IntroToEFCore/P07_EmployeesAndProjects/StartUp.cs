using System;
using System.Globalization;
using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace P07_EmployeesAndProjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var projects = context.Employees
                    .Where(emp =>
                        emp.EmployeesProjects.Any(s =>
                            s.Project.StartDate.Year >= 2001 && s.Project.StartDate.Year < 2003))
                    .Select(x => new
                    {
                        EmployeeName = x.FirstName + " " + x.LastName,
                        ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
                        Projects = x.EmployeesProjects.Select(s => new
                        {
                            ProjectName = s.Project.Name,
                            StartDate = s.Project.StartDate,
                            EndDate = s.Project.EndDate
                        }).ToArray()
                    })
                    .Take(30)
                    .ToArray();

                using (StreamWriter sw = new StreamWriter("../SoftuniData.txt"))
                {
                    foreach (var e in projects)
                    {
                        sw.WriteLine($"{e.EmployeeName} - Manager: {e.ManagerName}");

                        foreach (var proj in e.Projects)
                        {
                            sw.WriteLine($"--{proj.ProjectName} - {proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {proj.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) ?? "not finished"}");
                        }
                    }
                }
            }
        }
    }
}
