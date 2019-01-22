using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace P08_AddressesByTown
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var addresses = context.Addresses
                    .Select(a => new
                    {
                        AddressText = a.AddressText,
                        TownName = a.Town.Name,
                        Count = a.Employees.Count
                    })
                    .OrderByDescending(e => e.Count)
                    .ThenBy(t => t.TownName)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .ToArray();

                using (StreamWriter sw = new StreamWriter("../SoftuniData.txt"))
                {
                    foreach (var a in addresses)
                    {
                        sw.WriteLine($"{a.AddressText}, {a.TownName} - {a.Count} employees");
                    }
                }
            }
        }
    }
}
