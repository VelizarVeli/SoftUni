using System;

namespace _03.Megapixels
{
    class Program
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double MP = (width * height) / 1000000;
            Console.WriteLine($"{width}x{height} => {Math.Round(MP,1)}MP");
        }
    }
}
