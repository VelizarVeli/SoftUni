using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;

namespace P14_DeleteProjectById
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var projects = context.EmployeesProjects
                    .Where(x => x.ProjectId == 2);

                context.EmployeesProjects.RemoveRange(projects);

                var project = context.Projects.Find(2);

                context.Projects.Remove(project);

                context.SaveChanges();

                var proj = context.Projects.Take(10).ToArray();

                using (StreamWriter sw = new StreamWriter("../Employees.txt"))
                {
                    foreach (var p in proj)
                    {
                        sw.WriteLine(p.Name);
                    }
                }
            }
        }
    }
}
