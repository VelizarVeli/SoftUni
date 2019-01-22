using System;

namespace _03.CarToGo
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            double price = 0;
            string type = "";
            string Class = "";

            if (budget <= 100)
            {
                Class = "Economy class";
                if (season == "summer")
                {
                    type = "Cabrio";
                    price = budget * 0.35;
                }
                else
                {
                    type = "Jeep";
                    price = budget * 0.65;
                }
            }
            else if (budget > 100 && budget <=500)
            {
                Class = "Compact class";
                if (season == "summer")
                {
                    type = "Cabrio";
                    price = budget * 0.45;
                }
                else
                {
                    type = "Jeep";
                    price = budget * 0.8;
                }
            }
            else
            {
                Class = "Luxury class";
               
                    type = "Jeep";
                    price = budget * 0.9;
            }
            Console.WriteLine(Class);
            Console.WriteLine($"{type} - {price:f2}");
        }
    }
}
