using System;
using System.Collections.Generic;
using System.Linq;

namespace test3
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> test = new Queue<char>();
            char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                test.Enqueue(input[i]);
            }
            int testinggg = test.Count;
            for (int i = 0; i < testinggg; i++)
            {

                    string tester = charr
                
            }
        }
    }
}
