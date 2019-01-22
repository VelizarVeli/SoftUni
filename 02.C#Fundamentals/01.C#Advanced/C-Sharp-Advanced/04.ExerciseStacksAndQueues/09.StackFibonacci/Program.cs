using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Stack<long> fibi = new Stack<long>();
            fibi.Push(0);
            fibi.Push(1);
            if (N == 0)
            {
                Console.WriteLine(0);
            }

            else
            {
                for (int i = 0; i < N - 1; i++)
                {
                    long first = fibi.Pop();
                    long second = fibi.Pop();
                    fibi.Push(first);
                    fibi.Push(first + second);
                }
                Console.WriteLine(fibi.Peek());
            }
        }
    }
}
