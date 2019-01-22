using System;
using System.Collections.Generic;

namespace _01.ReverseString
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            foreach (var ch in input)
            {
                stack.Push(ch);
            }
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
