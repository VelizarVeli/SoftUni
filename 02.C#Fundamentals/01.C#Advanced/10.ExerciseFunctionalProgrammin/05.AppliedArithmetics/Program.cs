using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            string input = Console.ReadLine().ToLower();
            List<int> numbersCur = new List<int>();
            while (input != "end")
            {
                if (input == "add")
                {
                    numbers = numbers.Select(n => n + 1).ToList();
                }
                else if(input == "multiply")
                {
                    numbers = numbers.Select(n => n * 2).ToList();
                }
                else if (input == "subtract")
                {
                    numbers = numbers.Select(n => n - 1).ToList();
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                input = Console.ReadLine().ToLower();
            }
        }
    }
}
