using System;

namespace _12.FibonacciNumber
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int num0 = 1;
            int num1 = 1;

            for (int i = 0; i < n - 1; i++)
            {
                int numNext = num0 + num1;
                num0 = num1;
                num1 = numNext;
            }
            Console.WriteLine(num1);
        }
    }
}
