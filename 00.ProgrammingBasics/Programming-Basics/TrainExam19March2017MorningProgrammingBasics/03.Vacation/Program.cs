using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string location = "";
            string place = "";
            double price = 0;

            if (budget <= 1000)
            {
                place = "Camp";
                if (season == "summer")
                {
                    location = "Alaska";
                    price = budget - (budget * 0.35);
                }
                else
                {
                    location = "Morocco";
                    price = budget - (budget * 0.55);

                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                place = "Hut";
                if (season == "summer")
                {
                    location = "Alaska";
                    price = budget - (budget * 0.20);
                }
                else
                {
                    location = "Morocco";
                    price = budget - (budget * 0.40);

                }
            }
            else if (budget > 3000)
            {
                place = "Hotel";
                if (season == "summer")
                {
                    location = "Alaska";
                    price = budget - (budget * 0.10);
                }
                else
                {
                    location = "Morocco";
                    price = budget - (budget * 0.10);
                }
            }
            Console.WriteLine($"{location} - {place} - {price:f2}");
        }
    }
}
