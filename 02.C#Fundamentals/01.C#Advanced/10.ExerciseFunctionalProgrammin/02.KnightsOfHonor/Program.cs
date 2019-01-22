using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                Action<string> appendSir = message => Console.WriteLine($"Sir {message}");
                appendSir(input[i]);
            }
        }
    }
}
