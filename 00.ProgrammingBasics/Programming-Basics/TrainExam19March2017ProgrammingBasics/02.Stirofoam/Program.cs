using System;

namespace _02.Stirofoam
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            double sqHouse = double.Parse(Console.ReadLine());
            int windows = int.Parse(Console.ReadLine());
            double stiroporInPack = double.Parse(Console.ReadLine());
            double pricePack = double.Parse(Console.ReadLine());

            double allSq = (sqHouse - (windows * 2.4));
            allSq += allSq * 0.1;
            double neededPacks = Math.Ceiling(allSq / stiroporInPack);
            double spent = pricePack * neededPacks;
            if (spent > budget)
            {
                Console.WriteLine($"Need more: {spent - budget:f2}");
            }
            else
            {
                Console.WriteLine($"Spent: {spent:f2}");
                Console.WriteLine($"Left: {budget - spent:f2}");
            }
        }
    }
}
