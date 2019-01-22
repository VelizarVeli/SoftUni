using System;

namespace _03.SchoolCamp
{
    class Program
    {
        static void Main()
        {
            string season = Console.ReadLine().ToLower();
            string gender = Console.ReadLine().ToLower();
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            string sport = "";
            double price = 0;

            if (season == "winter" && gender == "girls")
            {
                sport = "Gymnastics";
                price = 9.6 * students * nights;
            }
            else if (season == "winter" && gender == "boys")
            {
                sport = "Judo";
                price = 9.6 * students * nights;
            }
            else if (season == "winter" && gender == "mixed")
            {
                sport = "Ski";
                price = 10 * students * nights;
            }
            else if (season == "spring" && gender == "girls")
            {
                sport = "Athletics";
                price = 7.2 * students * nights;
            }
            else if (season == "spring" && gender == "boys")
            {
                sport = "Tennis";
                price = 7.2 * students * nights;
            }
            else if (season == "spring" && gender == "mixed")
            {
                sport = "Cycling";
                price = 9.5 * students * nights;
            }
            else if (season == "summer" && gender == "girls")
            {
                sport = "Volleyball";
                price = 15 * students * nights;
            }
            else if (season == "summer" && gender == "boys")
            {
                sport = "Football";
                price = 15 * students * nights;
            }
            else if (season == "summer" && gender == "mixed")
            {
                sport = "Swimming";
                price = 20 * students * nights;
            }

            if (students >= 50)
            {
                price = price / 2;
            }
            else if (students >= 20 && students < 50)
            {
                price = price - (price * 0.15);
            }
            else if (students >= 10 && students < 20)
            {
                price = price - (price * 0.05);
            }
            Console.WriteLine($"{sport} {price:f2} lv.");
        }
    }
}
