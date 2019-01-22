using System;

namespace _09.House
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int stars = 0;

            if (N % 2 == 0)
            {
                stars = 2;
            }
            else
            {
                stars = 1;
            }
            for (int i = 0; i < (N + 1) / 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('-',(N - stars) / 2), new string('*',stars));
                stars += 2;
            }
            for (int i = 0; i < N / 2; i++)
            {
                Console.WriteLine("|{0}|", new string('*', N - 2));
            }
        }
    }
}
