using System.IO;
using P02_DatabaseFirst.Data;
using System.Linq;
using P02_DatabaseFirst.Data.Models;

namespace P06_AddingANewAddressAndUpdatingEmployee
{
    class StartUp
    {
        static void Main(string[] args)
        {


            using (SoftUniContext context = new SoftUniContext())
            {
                Address address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                var nakov = context.Employees.FirstOrDefault(x => x.LastName == "nakov");

                nakov.Address = address;

                context.SaveChanges();

                var addresses = context.Employees
                    .OrderByDescending(a => a.AddressId)
                    .Select(a => a.Address.AddressText)
                    .Take(10)
                    .ToArray();

                using (StreamWriter sw = new StreamWriter("../Employees.txt"))
                {
                    foreach (var employee in addresses)
                    {
                        sw.WriteLine(employee);
                    }
                }
            }
        }
    }
}
