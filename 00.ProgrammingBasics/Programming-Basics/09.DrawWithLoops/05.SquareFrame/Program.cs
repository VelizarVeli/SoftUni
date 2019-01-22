using System;

namespace _05.SquareFrame
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            Console.Write("+ ");
            for (int i = 0; i < N - 2; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine("+ ");

            for (int i = 0; i < N - 2; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < N - 2; j++)
                {
                    Console.Write("- ");
                }
                Console.WriteLine("|");
            }
            Console.Write("+ ");
            for (int i = 0; i < N - 2; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine("+ ");
        }
    }
}
