using System;

namespace _03.SquareOfStars
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            for (int r = 1; r <= N; r++)
            {
                Console.Write("*");
                for (int c = 1; c < N; c++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }
    }
}
