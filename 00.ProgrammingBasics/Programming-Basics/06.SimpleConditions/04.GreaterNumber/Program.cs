using System;

namespace _04.GreaterNumber
{
    class Program
    {
        static void Main()
        {
            int digit1 = int.Parse(Console.ReadLine());
            int digit2 = int.Parse(Console.ReadLine());

            if (digit1 > digit2)
            {
                Console.WriteLine(digit1);
            }
            else Console.WriteLine(digit2);
        }
    }
}
