using System;

namespace _03.PowersOfTwo
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            for (int i = 0; i <= 2 * n / 2; i+=2)
            {
                Console.WriteLine(num);
                num = 2 * num * 2;
            }
        }
    }
}
