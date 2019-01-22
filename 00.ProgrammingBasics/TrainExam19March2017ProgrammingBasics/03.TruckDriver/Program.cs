using System;

namespace _03.TruckDriver
{
    class Program
    {
        static void Main()
        {
            string season = Console.ReadLine().ToLower();
            double kmPerMonth = double.Parse(Console.ReadLine());

            double total = 0;
            double km = kmPerMonth * 4;
            if ((season == "spring" || season == "autumn") && kmPerMonth <= 5000)
            {
                total = (km * 0.75) - (km * 0.75 * 0.1);
            }
            else if ((season == "spring" || season == "autumn" && kmPerMonth > 5000) && kmPerMonth <= 10000)
            {
                total = (km * 0.95) - (km * 0.95 * 0.1);

            }
            else if (10000 < kmPerMonth && (kmPerMonth <= 20000 && season == "summer" || season == "winter" || season == "spring" || season == "autumn"))
            {
                total = (km * 1.45) - (km * 1.45 * 0.1);

            }
            else if (season == "summer" && kmPerMonth <= 5000)
            {
                total = (km * 0.9) - (km * 0.9 * 0.1);

            }
            else if (season == "summer" && kmPerMonth > 5000 && kmPerMonth <= 10000)
            {
                total = (km * 1.1) - (km * 1.1 * 0.1);

            }
            else if (season == "winter" && kmPerMonth <= 5000)
            {
                total = (km * 1.05) - (km * 1.05 * 0.1);

            }
            else if (season == "winter" && kmPerMonth > 5000 && kmPerMonth <= 10000)
            {
                total = (km * 1.25) - (km * 1.25 * 0.1);

            }
            Console.WriteLine($"{total:f2}");
        }
    }
}
