using System;
using System.Collections.Generic;

namespace _08.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Queue<long> fibi = new Queue<long>();
            fibi.Enqueue(1);
            fibi.Enqueue(1);
            for (int i = 0; i < N - 1; i++)
            {
                long first = fibi.Dequeue();
                long second = fibi.Peek();
                fibi.Enqueue(first + second);
            }
            Console.WriteLine(fibi.Peek());
        }
    }
}
