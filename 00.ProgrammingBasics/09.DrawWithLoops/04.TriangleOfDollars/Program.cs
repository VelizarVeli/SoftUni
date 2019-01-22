using System;

namespace _04.TriangleOfDollars
{
    class Program
    {
        static void Main()
        {


            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                     Console.Write("$ ");
                }
                Console.WriteLine();
            }
        }
    }
}