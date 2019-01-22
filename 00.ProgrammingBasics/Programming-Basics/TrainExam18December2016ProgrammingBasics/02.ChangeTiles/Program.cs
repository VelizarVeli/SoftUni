using System;

namespace _02.ChangeTiles
{
    class Program
    {
        static void Main()
        {
            double saved = double.Parse(Console.ReadLine());
            double floorWidth = double.Parse(Console.ReadLine());
            double floorLength = double.Parse(Console.ReadLine());
            double trLength = double.Parse(Console.ReadLine());
            double trHeight = double.Parse(Console.ReadLine());
            double tilePrice = double.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            double floorArea = floorWidth * floorLength;
            double tileArea = (trHeight * trLength) / 2;
            double neededTiles = Math.Ceiling(floorArea / tileArea) + 5;
            double total = neededTiles * tilePrice + salary;
            double diff = Math.Abs(total - saved);

            if(total <= saved)
            {
                Console.WriteLine($"{diff:f2} lv left.");
            }
            else
                Console.WriteLine($"You'll need {diff:f2} lv more.");
        }
    }
}
