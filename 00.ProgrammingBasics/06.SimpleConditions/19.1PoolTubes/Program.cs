using System;

namespace _19._1PoolTubes
{
    class Program
    {
        static void Main()
        {
            double volume = double.Parse(Console.ReadLine());
            double P1 = double.Parse(Console.ReadLine());
            double P2 = double.Parse(Console.ReadLine());
            double H = double.Parse(Console.ReadLine());

            double P1Liters = P1 * H;
            double P2Liters = P2 * H;
            double water = P1Liters + P2Liters;


            var overflow = water - volume;

            if (water <= volume)
            {
                double percWater = Math.Truncate(water / (volume / 100));
                double perc1 = Math.Truncate(P1Liters / (water / 100));
                double perc2 = Math.Truncate(P2Liters / (water / 100));

                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.", percWater, perc1, perc2);
            }
            else
            Console.WriteLine("For {0} hours the pool overflows with {1:f1} liters.", H, overflow);
        }
    }
}
