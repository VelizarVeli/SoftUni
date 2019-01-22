using System;

namespace _02.WorkHours
{
    class Program
    {
        static void Main()
        {
            int neededHours = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int workDays = int.Parse(Console.ReadLine());

            int workHours = workers * workDays * 8;
            int diff = Math.Abs(workHours - neededHours);

            int penalties = diff * workDays;

            if (neededHours <= workHours)
            {
            Console.WriteLine($"{diff} hours left");
            }
            else
            {
            Console.WriteLine($"{diff} overtime");
                Console.WriteLine($"Penalties: {penalties}");
            }

        }
    }
}
