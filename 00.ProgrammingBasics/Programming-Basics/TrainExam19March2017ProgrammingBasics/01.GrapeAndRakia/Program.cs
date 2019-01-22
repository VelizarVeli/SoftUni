using System;

namespace _01.GrapeAndRakia
{
    class Program
    {
        static void Main()
        {
            double square = double.Parse(Console.ReadLine());
            double kgSqM = double.Parse(Console.ReadLine());
            double brak = double.Parse(Console.ReadLine());

            double grapesKg = square * kgSqM - brak;
            double grapesForSale = grapesKg - (grapesKg * 0.45);
            double rakiaLiters = (grapesKg - (grapesKg * 0.55)) / 7.5;

            Console.WriteLine($"{rakiaLiters * 9.8:f2}");
            Console.WriteLine($"{grapesForSale * 1.5:f2}");
        }
    }
}
