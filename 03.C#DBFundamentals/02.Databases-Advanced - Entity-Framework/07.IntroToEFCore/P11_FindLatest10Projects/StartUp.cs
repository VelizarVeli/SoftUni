using System;
using System.Globalization;
using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace P11_FindLatest10Projects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var projects = context.Projects
                    .OrderByDescending(x => x.StartDate)
                    .Take(10)
                    .Select(p => new
                    {
                        p.Name,
                        p.Description,
                        p.StartDate
                    })
                    .OrderBy(p => p.Name)
                    .ToList();

                using (StreamWriter sw = new StreamWriter("../Employees.txt"))
                {
                    foreach (var p in projects)
                    {

                        sw.WriteLine($"{p.Name}{Environment.NewLine}{p.Description}{Environment.NewLine}{p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                    }
                }
            }
        }
    }
}
