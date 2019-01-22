using System;

namespace _10.Diamond
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int stars = 0;

            if (n % 2 == 0)
            {
                stars = 2;
                Console.WriteLine("{0}{1}{0}", new string('-', (n - stars) / 2), new string('*', stars));

            }
            else
            {
                stars = 1;
                Console.WriteLine("{0}{1}{0}", new string('-', (n - stars) / 2), new string('*', stars));

            }
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('-', (n - stars) / 2), new string('*', stars));
                stars += 2;
            }
        }
    }
}
