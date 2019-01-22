using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._1.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> customers = new List<Person>();
            List<Product> prices = new List<Product>();
            bool check = true;
            string[] people = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var person in people)
            {
                string name = person.Split('=', StringSplitOptions.RemoveEmptyEntries)[0];
                decimal money = decimal.Parse(person.Split('=', StringSplitOptions.RemoveEmptyEntries)[1]);
                Person customer;
                try
                {
                    customer = new Person(name, money);
                    customers.Add(customer);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    check = false;
                    break;
                }
            }

            string[] products = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            if (check)
            {
                foreach (var product in products)
                {
                    string name = product.Split('=', StringSplitOptions.RemoveEmptyEntries)[0];
                    decimal price = decimal.Parse(product.Split('=', StringSplitOptions.RemoveEmptyEntries)[1]);
                    Product currentProduct;
                    try
                    {
                        currentProduct = new Product(name, price);
                        prices.Add(currentProduct);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string customerName = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                string productName = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

                Person currentCustomer = customers.FirstOrDefault(a => a.Name == customerName);
                var currentPrice = prices.FirstOrDefault(a => a.Name == productName);
                if (currentCustomer != null && currentPrice != null)
                {
                    if (currentCustomer.Money >= currentPrice.Cost)
                    {
                        Console.WriteLine($"{customerName} bought {productName}");
                        currentCustomer.Money -= currentPrice.Cost;
                        currentCustomer.AddProduct(productName);
                    }

                    else
                    {
                        Console.WriteLine($"{customerName} can't afford {productName}");
                    }
                }
                else
                {
                    break;
                }
            }

            foreach (var customer in customers)
            {
                string producti = string.Join(", ", customer.Products);

                if (customer.Products.Count != 0)
                {
                    Console.WriteLine($"{customer.Name} - {producti}");
                }
                else
                {
                    Console.WriteLine($"{customer.Name} - Nothing bought");
                }
            }
        }
    }
}
