using System;
using System.Collections.Generic;
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
                FillItems(context);

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    CommandController(context, input);
                }

                var id = int.Parse(Console.ReadLine());
                PrintNumberOfItems(context, id);
            }
        }

        private static void PrintNumberOfItems(ShopHierarchyDbContext context, int id)
        {
            var customer = context.Customers
                .Where(i => i.Id == id)
                .Select(o => new
                {
                    Orders = o.Orders.Select(c => new
                    {
                        o.Id,
                        items = c.Items.Count
                    })
                        .OrderBy(c => c.Id),
                    Reviews = o.Reviews.Count
                })
                .FirstOrDefault();

            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"order {order.Id}: {order.items} items");
            }

            Console.WriteLine($"reviews: {customer.Reviews}");
        }

        private static void FillItems(ShopHierarchyDbContext context)
        {
            string[] itemPrice = Console.ReadLine().Split(';');
            var name = itemPrice[0];
            var price = decimal.Parse(itemPrice[1]);
            List<Item> items = new List<Item>();
            while (itemPrice[0] != "END")
            {
                Item item = new Item
                {
                    Name = name,
                    Price = price
                };
                items.Add(item);
                itemPrice = Console.ReadLine().Split(';');
            }

            context.AddRange(items);
            context.SaveChanges();
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
                    CustomerOrder(context, commandName[1].Split(';').Select(int.Parse).ToArray());
                    break;
                case "review":

                    CustomerReview(context, commandName[1].Split(';').Select(int.Parse).ToArray());
                    break;
            }
        }

        private static void CustomerReview(ShopHierarchyDbContext context, int[] customerId)
        {
            Review review = new Review
            {
                CustomerId = customerId[0],
                ItemId = customerId[1]
            };
            context.Add(review);
            context.SaveChanges();
        }

        private static void CustomerOrder(ShopHierarchyDbContext context, int[] ids)
        {
            int customerId = ids[0];
            Order order = new Order { CustomerId = customerId };
            for (int i = 1; i < ids.Length; i++)
            {
                var itemId = ids[i];

                order.Items.Add(new ItemOrder
                {
                    ItemId = itemId
                });
            }

            context.Add(order);
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
