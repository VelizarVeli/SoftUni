using System;

namespace _01._1.ClassBox
{
    class Program
    {
        static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = null;

            try
            {
                box = new Box(length, width, height);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea(length, width, height):f2}");
            Console.WriteLine($"Lateral Surface Area - {box.CalculateLAteralSurfaceArea(length, width, height):f2}");
            Console.WriteLine($"Volume - {box.CalculateVolume(length, width, height):f2}");

        }
    }
}
