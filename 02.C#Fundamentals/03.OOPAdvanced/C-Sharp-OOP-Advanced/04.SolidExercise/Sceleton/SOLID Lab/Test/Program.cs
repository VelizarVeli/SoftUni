using System;

namespace NeighbourWars
{
    class NeighbourWars
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());

            int peshoHealth = 100;
            int goshoHealth = 100;
            int counter = 1;
            for (int i = 1; ; i++)
            {
                if (i % 2 == 1)
                {
                    goshoHealth -= peshoDamage;
                    if (goshoHealth <= 0)
                    {
                        Console.WriteLine($"Pesho won in {counter}th round.");
                        return;
                    }
                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHealth} health.");
                }

                if (i % 2 == 0)
                {
                    peshoHealth -= goshoDamage;
                    if (peshoHealth <= 0)
                    {
                        Console.WriteLine($"Gosho won in {counter}th round.");
                        return;
                    }
                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHealth} health.");
                }

                if (counter == 3 || counter == 6 || counter == 9 || counter == 12)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }
                counter++;
            }
        }
    }
}