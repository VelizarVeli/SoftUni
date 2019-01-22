using System;

namespace _12.AreaOfFigures
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            if (input == "square")
            {
                var sqSide = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(sqSide * sqSide, 3));
            }

            else if (input == "rectangle")
            {
                var side1 = double.Parse(Console.ReadLine());
                var side2 = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(side1 * side2, 3));
            }

            else if (input == "circle")
            {
                var radius = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(Math.PI * radius * radius, 3));
            }

            else if (input == "triangle")
            {
                var side = double.Parse(Console.ReadLine());
                var h1 = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(side * h1 / 2, 3));
            }
        }
    }
}
