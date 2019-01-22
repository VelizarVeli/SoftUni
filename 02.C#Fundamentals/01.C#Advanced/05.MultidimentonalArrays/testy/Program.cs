using System;
using System.Linq;

namespace testy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var sizes = new int[3];
            foreach (var number in numbers)
            {
                sizes[number % 3]++;
            }
        }
    }
}
