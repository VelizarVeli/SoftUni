using System;

namespace _10.CheckPrime
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool prime = true;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime == false || n < 2)
            {
                Console.WriteLine("Not Prime");
            }
            else
            {
                Console.WriteLine("Prime");
            }
        }
    }
}