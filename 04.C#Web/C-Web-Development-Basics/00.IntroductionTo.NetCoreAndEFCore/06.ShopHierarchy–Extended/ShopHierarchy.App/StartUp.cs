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
                PrintCustomersWithOrdersAndReviewsCount(context);
            }
        }

        private static void PrintCustomersWithOrdersAndReviewsCount(ShopHierarchyDbContext context)
        {
            var customers = context.Customers
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count
                })
                .OrderByDescending(o => o.Orders)
                .ThenBy(r => r.Reviews);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Name);

                Console.WriteLine($"Orders: {customer.Orders}");
                Console.WriteLine($"Reviews: {customer.Reviews}");
            }
        }

        private static void CommandController(ShopHierarchyDbContext context, string input)
        {
            string[] commandName = input.Split('-');
            string command = commandName[0];
            switch (command)
            {
                case "register":
                    RegisterCustomer(context, input);
                    break;
                case "order":
                    int customerId = int.Parse(commandName[1]);
                    CustomerOrder(context, customerId);
                    break;
                case "review":
                    int customer = int.Parse(commandName[1]);
                    CustomerReview(context, customer);
                    break;
            }
        }

        private static void CustomerReview(ShopHierarchyDbContext context, int customerId)
        {
            Review review = new Review() { CustomerId = customerId };
            EntityEntry<Review> result = context.Reviews.Add(review);
            Customer customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
            customer.Reviews.Add(result.Entity);
            context.SaveChanges();
        }

        private static void CustomerOrder(ShopHierarchyDbContext context, int customerId)
        {
            Order order = new Order() { CustomerId = customerId };
            EntityEntry<Order> result = context.Orders.Add(order);
            Customer customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
            customer.Orders.Add(result.Entity);

            context.SaveChanges();
        }

        private static void RegisterCustomer(ShopHierarchyDbContext context, string input)
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
