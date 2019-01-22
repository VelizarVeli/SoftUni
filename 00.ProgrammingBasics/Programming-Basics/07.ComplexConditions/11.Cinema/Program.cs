using System;

namespace _11.Cinema
{
    class Program
    {
        static void Main()
        {
            string projections = Console.ReadLine().ToLower();
            double rows = double.Parse(Console.ReadLine());
            double columns = double.Parse(Console.ReadLine());

            switch (projections)
            {
                case "premiere": Console.WriteLine($"{12 * rows * columns:f2} leva"); break;
                case "normal": Console.WriteLine($"{7.5 * rows * columns:f2} leva"); break;
                case "discount": Console.WriteLine($"{5 * rows * columns:f2} leva"); break;
            }
        }
    }
}
