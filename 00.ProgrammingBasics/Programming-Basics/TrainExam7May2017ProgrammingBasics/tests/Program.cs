using System;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int number = M * 100 + N * 10 + L;

            for (int i = M; i >= 1; i--)
            {
                for (int j = N; j >= 1; j--)
                {
                    for (int k = L; k >= 1; k--)
                    {
                        Console.WriteLine($"{i}{j}{k}");
                    }
                }
            }
        }
    }
}
