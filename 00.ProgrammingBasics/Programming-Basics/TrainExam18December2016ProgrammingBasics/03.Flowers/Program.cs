using System;

namespace _03.Flowers
{
    class Program
    {
        static void Main()
        {
            int hrizantemi = int.Parse(Console.ReadLine());
            double rozi = double.Parse(Console.ReadLine());
            double laleta = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string holiday = Console.ReadLine().ToLower();

            double priceHrizantemi = 0;
            double priceRozi = 0;
            double priceLaleta = 0;

            if (season == "spring" || season == "summer")
            {
                priceHrizantemi = hrizantemi * 2;
                priceRozi = rozi * 4.1;
                priceLaleta = laleta * 2.5;
            }
            else if (season == "winter" || season == "autumn")
            {
                priceHrizantemi = hrizantemi * 3.75;
                priceRozi = rozi * 4.5;
                priceLaleta = laleta * 4.15;
            }
            double total = priceHrizantemi + priceRozi + priceLaleta;
            if (laleta >= 7 && season == "spring")
            {
                total = total * 0.95;
            }
            if(rozi >= 10 && season == "winter")
            {
                total = total * 0.9;
            }
            if(hrizantemi + rozi + laleta >= 20)
            {
                total = total * 0.8;
            }
            if(holiday == "y")
            {
                total = total * 1.15;
            }
            Console.WriteLine($"{total+2:f2}");
        }
    }
}
