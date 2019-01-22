using System;
using System.Linq;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var sizes = new int[3];
            foreach (var num in input)
            {
                sizes[Math.Abs(num % 3)]++;
            }

            int[][] jaggedArray = new int[3][];

            for (int counter = 0; counter < sizes.Length; counter++)
            {
                jaggedArray[counter] = new int[sizes[counter]];
            }
            int[] index = new int[3];
            foreach (var number in input)
            {
                var remainder = Math.Abs(number % 3);
                jaggedArray[remainder][index[remainder]] = number;
                index[remainder]++;
            }
            for (int rows = 0; rows < jaggedArray.Length; rows++)
            {
                for (int columns = 0; columns < jaggedArray[rows].Length; columns++)
                {
                    Console.Write(jaggedArray[rows][columns]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
