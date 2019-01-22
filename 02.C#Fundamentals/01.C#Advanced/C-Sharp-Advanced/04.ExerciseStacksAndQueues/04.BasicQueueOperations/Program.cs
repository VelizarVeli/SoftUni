using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main()
        {
            int[] guidelines = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            Queue<int> stack = new Queue<int>();
            int numberOfElementsToPush = guidelines[0];
            int numberOfElementsToPop = guidelines[1];
            int lookingFor = guidelines[2];
            int max = Int32.MaxValue;
            int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < numberOfElementsToPush; i++)
            {
                stack.Enqueue(input[i]);
            }
            int checky = Math.Min(numberOfElementsToPop, stack.Count);
            for (int j = 0; j < checky; j++)
            {
                stack.Dequeue();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(lookingFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                int lengthy = stack.Count;
                for (int i = 0; i < lengthy; i++)
                {
                    int monu = stack.Dequeue();
                    if (monu < max)
                    {
                        max = monu;
                    }
                }
                Console.WriteLine(max);
            }
        }
    }
}
