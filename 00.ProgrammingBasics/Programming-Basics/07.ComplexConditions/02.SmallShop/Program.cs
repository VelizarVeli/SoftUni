using System;

namespace _02.SmallShop
{
    class Program
    {
        static void Main()
        {
            string product = Console.ReadLine().ToLower();
            string city = Console.ReadLine().ToLower();
            double price = double.Parse(Console.ReadLine());

            if (city == "sofia")
            {
                if (product == "coffee")
                    Console.WriteLine(price * 0.5);
                else if (product == "water")
                    Console.WriteLine(price * 0.8);
                else if (product == "beer")
                    Console.WriteLine(price * 1.2);
                else if (product == "sweets")
                    Console.WriteLine(price * 1.45);
                else if (product == "peanuts")
                    Console.WriteLine(price * 1.6);
            }
            if (city == "plovdiv")
            {
                if (product == "coffee")
                    Console.WriteLine(price * 0.4);
                else if (product == "water")
                    Console.WriteLine(price * 0.7);
                else if (product == "beer")
                    Console.WriteLine(price * 1.15);
                else if (product == "sweets")
                    Console.WriteLine(price * 1.30);
                else if (product == "peanuts")
                    Console.WriteLine(price * 1.5);
            }
            else if (city == "varna")
            {
                if (product == "coffee")
                    Console.WriteLine(price * 0.45);
                else if (product == "water")
                    Console.WriteLine(price * 0.7);
                else if (product == "beer")
                    Console.WriteLine(price * 1.1);
                else if (product == "sweets")
                    Console.WriteLine(price * 1.35);
                else if (product == "peanuts")
                    Console.WriteLine(price * 1.55);
            }
        }
    }
}
