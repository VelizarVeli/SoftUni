using System;
namespace _21.Harvest
{
    class Program
    {
        static void Main()
        {
            int area = int.Parse(Console.ReadLine());
            double grapePerSqM = double.Parse(Console.ReadLine());
            int neededLitres = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            double rekolta = area * grapePerSqM;
            double wine = ((rekolta * 40) / 100) / 2.5;
            double diffWine = Math.Abs(wine - neededLitres);
            
            if (wine < neededLitres)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(diffWine)} liters wine needed.");
            }
            else
            {
                double winePerWorker = Math.Ceiling(diffWine / workers);
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                Console.WriteLine($"{Math.Ceiling(diffWine)} liters left -> {winePerWorker} liters per person.");
            }
        }
    }
}
