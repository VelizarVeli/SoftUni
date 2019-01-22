using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbersWithAStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> reverse = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                reverse.Push(input[i]);
            }
            long length = reverse.Count;
            while (reverse.Count != 0)
            {
                    Console.Write($"{reverse.Pop()} ");
            }
        }
    }
}
