using System;

namespace _19.PoolTubes
{
    class Program
    {
        static void Main()
        {
            var volume = double.Parse(Console.ReadLine());
            var P1 = double.Parse(Console.ReadLine());
            var P2 = double.Parse(Console.ReadLine());
            var H = double.Parse(Console.ReadLine());

            var waterP1 = H * P1;
            var waterP2 = H * P2;

            var water = waterP1 + waterP2;

            if (volume >= water)
            {
                double all = water / (volume / 100);
                double percentage1 = waterP1 / (volume / 100);
                double percentage2 = waterP2 / (volume / 100);

                Console.WriteLine("The pool is {0:F0}% full. Pipe 1: {1:F0}%. Pipe 2: {2:F0}%.", all, percentage1, percentage2);
            }

            else 
            {
                double all = water - volume;
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.", H, all);
            }
        }
    }
}
