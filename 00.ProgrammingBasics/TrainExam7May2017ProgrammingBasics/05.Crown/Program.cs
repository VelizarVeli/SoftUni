using System;

namespace _05.Crown
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int l = 1;
            int spaces = N - 5;
            int m = 1;
            int o = 0;

            Console.Write("@");
            for (int i = 0; i < N - 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("@");
            for (int i = 0; i < N - 2; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("@");

            Console.WriteLine("**{0}*{0}**", new string(' ', N - 3));

            for (int i = 0; i < N / 2 - 1; i++)
            {
                Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', l), new string(' ', spaces), new string('.', m));
                l++;
                o++;
                if(spaces <= 1)
                {
                    break;
                }
                spaces -= 2;
                m += 2;
            }

            Console.WriteLine("*{0}*{1}*{0}*", new string('.', l), new string('.',m + 2));
            Console.WriteLine("*{0}{1}.{1}{0}*", new string('.', l + 1), new string('*',o));

            for (int i = 0; i < (2 * N) - 1; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            for (int i = 0; i < (2 * N) - 1; i++)
            {
                Console.Write("*");
            }
        }
    }
}
