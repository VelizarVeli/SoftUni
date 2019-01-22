using System;

namespace _01.PaintingHouse
{
    class Program
    {
        static void Main()
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double green = ((x * x - 1.2 * 2) + (x * x) + (x * y - 1.5 * 1.5) * 2) / 3.4;
            double red = ((2 * ((x * h) / 2)) + (x * y) * 2) / 4.3;

            Console.WriteLine($"{green:f2}");
            Console.WriteLine($"{red:f2}");
        }
    }
}
