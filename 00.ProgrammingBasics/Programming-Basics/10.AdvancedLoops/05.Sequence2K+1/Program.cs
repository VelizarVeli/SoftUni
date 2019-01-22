using System;

namespace _06.NumberInRange1._._100
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine(num);
                num = num * 2 + 1;
                if (num > n)
                {
                    break;
                }
            }
        }
    }
}
