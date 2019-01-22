using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> maxStack = new Stack<int>();
            maxStack.Push(int.MinValue);
            for (int i = 0; i < N; i++)
            {
                int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    var element = input[1];
                    stack.Push(element);
                    if (element >= maxStack.Peek())
                    {
                        maxStack.Push(element);
                    }
                }
                else if (input[0] == 2)
                {
                    var poppedElement = stack.Pop();
                    if (maxStack.Peek() == poppedElement)
                    {
                        maxStack.Pop();
                    }
                }
                else
                {
                    int maxElement = maxStack.Peek();
                    Console.WriteLine(maxElement);
                }
            }
        }
    }
}
