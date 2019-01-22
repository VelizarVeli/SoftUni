using System;

namespace _07.TrainingHallEquipment
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            int items = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 1; i <= items; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                int count = int.Parse(Console.ReadLine());
                sum += price * count;
                if (count == 1)
                {
                    Console.WriteLine($"Adding {count} {name} to cart.");
                }
                else
                {
                    Console.WriteLine($"Adding {count} {name}s to cart.");

                }
            }
            Console.WriteLine($"Subtotal: ${sum:f2}");
            if(budget >= sum)
            {
                Console.WriteLine($"Money left: ${budget - sum:f2}");
            }
            else
                Console.WriteLine($"Not enough. We need ${sum - budget:f2} more.");
        }
    }
}
