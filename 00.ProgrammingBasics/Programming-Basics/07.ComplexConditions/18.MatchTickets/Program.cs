using System;

namespace _18.MatchTickets
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine().ToLower();
            int people = int.Parse(Console.ReadLine());

            var VIP = 499.99;
            var normal = 249.99;
            var withoutTransport = 0.0;
            var moneyForTickets = 0.0;
            

            if (people > 0 && people <= 4)
            {
                withoutTransport = budget - (budget * 0.75);
            }
            else if (people >= 5 && people <= 9)
            {
                withoutTransport = budget - (budget * 0.6);
            }
            else if (people >= 10 && people <= 24)
            {
                withoutTransport = budget - (budget * 0.5);
            }
            else if (people >= 25 && people <= 49)
            {
                withoutTransport = budget - (budget * 0.4);
            }
            else if (people >= 49)
            {
                withoutTransport = budget - (budget * 0.25);
            }

            if (category == "normal")
            {
                moneyForTickets = normal * people;
            }
            else
            {
                moneyForTickets = VIP * people;
            }

            if (moneyForTickets + (budget - withoutTransport) > budget)
            {
                Console.WriteLine($"Not enough money! You need {(Math.Abs(moneyForTickets + (budget - withoutTransport) - budget)):f2} leva.");
            }
            else
            {
                Console.WriteLine($"Yes! You have {(Math.Abs(moneyForTickets + (budget - withoutTransport) - budget)):f2} leva left.");
            }
        }
    }
}
