using System;

namespace _02.Cups
{
    class Program
    {
        static void Main()
        {
            int cupsNeeded = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int workdays = int.Parse(Console.ReadLine());

            int workingHours = workers * workdays * 8;
            int cups = workingHours / 5;
            double money = cups * 4.2;
            double moneyNeeded = cupsNeeded * 4.2;
            var difference = Math.Abs(moneyNeeded - money);

            if (money > moneyNeeded)
            {
                Console.WriteLine($"{difference:f2} extra money");
            }
            else
                Console.WriteLine($"Losses: {difference:f2}");
        }
    }
}
