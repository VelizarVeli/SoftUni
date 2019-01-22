using System;

namespace _15.EqualNumbers
{
    class Program
    {
        static void Main()
        {
            var num1 = Console.ReadLine();
            var num2 = Console.ReadLine();
            var num3 = Console.ReadLine();

            if (num1 == num2 && num2 == num3)
            {
                Console.WriteLine("yes");
            }
            else
                Console.WriteLine("no");
        }
    }
}
