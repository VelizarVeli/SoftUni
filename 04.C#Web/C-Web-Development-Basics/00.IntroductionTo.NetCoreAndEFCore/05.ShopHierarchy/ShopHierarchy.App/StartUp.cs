using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopHierarchy.Data;
using ShopHierarchy.Models;

namespace ShopHierarchy.App
{
    class StartUp
    {
        static void Main()
        {
            using (var context = new ShopHierarchyDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                FillSalesmen(context);

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    CommandController(context, input);
                }
                PrintSalesmenWithCustomersCount(context);
            }
        }

        private static void CommandController(ShopHierarchyDbContext context, string input)
        {
            string[] commandName = input.Split('-');
            string command = commandName[0];
            switch (command)
            {
                case "register":
                    Register(context, input);
                    break;
            }
        }

        private static void Register(ShopHierarchyDbContext context, string input)
        {
            string[] registerTokens = input.Split(';');

            string[] inpSplit = registerTokens[0].Split('-');
            string customerName = inpSplit[1];
            int salesmanId = int.Parse(registerTokens[1]);

            Customer customer = new Customer() { Name = customerName };
            EntityEntry<Customer> result = context.Customers.Add(customer);
            Salesman salesman = context.Salesmen.FirstOrDefault(s => s.Id == salesmanId);
            salesman.Customers.Add(result.Entity);

            context.SaveChanges();
        }

        private static void PrintSalesmenWithCustomersCount(ShopHierarchyDbContext context)
        {
            var salesmen = context.Salesmen
                .Include(c => c.Customers)
                .OrderByDescending(c => c.Customers.Count)
                .ThenBy(x => x.Name);

            foreach (var salesman in salesmen)
            {
                int customersCount = salesman.Customers.Count;
                Console.WriteLine($"{salesman.Name} - {customersCount} customers");
            }
        }

        private static void FillSalesmen(ShopHierarchyDbContext context)
        {
            string[] salesmenNames = Console.ReadLine().Split(';');

            foreach (var name in salesmenNames)
            {
                Salesman salesman = new Salesman() { Name = name };
                context.Salesmen.Add(salesman);
            }

            context.SaveChanges();
        }
    }
}
