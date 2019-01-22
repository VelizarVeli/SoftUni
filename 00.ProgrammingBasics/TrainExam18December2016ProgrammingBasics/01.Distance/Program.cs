using System;

namespace _01.Distance
{
    class Program
    {
        static void Main()
        {
            double startSpeed = double.Parse(Console.ReadLine());
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double third = double.Parse(Console.ReadLine());

            double firstKM = startSpeed * (first / 60);

            double secondSpeed = startSpeed * 1.1;
            double secondKM = secondSpeed * (second / 60);

            double thirdSpeed = secondSpeed * 0.95;
            double thirdKM = thirdSpeed * (third / 60);

            double KM = firstKM + secondKM + thirdKM;

            Console.WriteLine($"{KM:f2}");
        }
    }
}
