using System;
using System.Numerics;
namespace _08.Factorial
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger fact = 1;

            do
            {
                fact = fact * n;
                n--;
            } while (n > 1);
            {
                Console.WriteLine(fact);
            }
        }
    }
}
