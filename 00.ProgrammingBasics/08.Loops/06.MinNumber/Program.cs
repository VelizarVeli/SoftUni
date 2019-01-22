using System;

namespace _06.MinNumber
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int min = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < min)
                {
                    min = num;
                }
            }
            Console.WriteLine(min);
        }
    }
}
