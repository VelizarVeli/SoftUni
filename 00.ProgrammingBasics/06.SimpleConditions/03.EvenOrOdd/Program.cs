using System;

namespace _03.EvenOrOdd
{
    class Program
    {
        static void Main()
        {
            int digit = int.Parse(Console.ReadLine());
            if (digit % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
