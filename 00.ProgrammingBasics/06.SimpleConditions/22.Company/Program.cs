using System;

namespace _22.Company
{
    class Program
    {
        static void Main()
        {
            int neededHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            double workingHours = 7.2 * days + (workers * 2 * days);
            var left = Math.Abs(workingHours - neededHours);

            if (neededHours <= workingHours)
            {
                Console.WriteLine($"Yes!{Math.Floor(left)} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Ceiling(left)} hours needed.");
            }
        }
    }
}
