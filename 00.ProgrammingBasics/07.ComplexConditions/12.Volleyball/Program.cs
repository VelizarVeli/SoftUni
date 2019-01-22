using System;

namespace _12.Volleyball
{
    class Program
    {
        static void Main()
        {
            string year = Console.ReadLine();
            double holydays = double.Parse(Console.ReadLine());
            double weekendsProvince = double.Parse(Console.ReadLine());

            double weekendsInSofia = 48 - weekendsProvince;
            double gamesInHolidays = holydays * (2.0 / 3);
            double gamesInSofia = weekendsInSofia * (3.0 / 4);

            double allGames = gamesInSofia + weekendsProvince + gamesInHolidays;

            if (year == "leap")
            {
                Console.WriteLine(Math.Truncate(allGames * 1.15));
            }
            else
                Console.WriteLine(Math.Truncate(allGames));
        }
    }
}
