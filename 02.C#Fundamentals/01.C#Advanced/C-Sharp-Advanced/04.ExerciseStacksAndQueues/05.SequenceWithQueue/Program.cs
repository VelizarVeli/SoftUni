using System;
using System.Collections.Generic;

namespace _05.SequenceWithQueue
{
    class Program
    {
        static void Main()
        {
            long N = long.Parse(Console.ReadLine());
            Queue<long> sequence = new Queue<long>();

            //s1
            sequence.Enqueue(N);
            Console.Write($"{sequence.Peek()} ");

            //s2
            sequence.Enqueue(sequence.Peek() + 1);
            sequence.Dequeue();
            Console.Write($"{sequence.Peek()} ");

            //s3
            sequence.Enqueue(2 * N + 1);
            sequence.Dequeue();
            Console.Write($"{sequence.Peek()} ");

            //s4
            sequence.Enqueue(N + 2);
            

        }
    }
}
