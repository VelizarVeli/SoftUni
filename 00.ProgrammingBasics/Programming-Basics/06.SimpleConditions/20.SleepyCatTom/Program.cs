using System;

namespace _20.SleepyCatTom
{
    class Program
    {
        static void Main()
        {
            var daysOff = int.Parse(Console.ReadLine());
            var workDays = 365 - daysOff;
            var playMinutes = daysOff * 127 + workDays * 63;
            var difference = Math.Abs(playMinutes - 30000);
            var H = difference / 60;
            var M = difference % 60;

            if (playMinutes > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{H} hours and {M} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{H} hours and {M} minutes less for play");
            }
        }
    }
}
