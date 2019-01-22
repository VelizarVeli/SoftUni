using System;

namespace _03._1.SquareOfStars
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
