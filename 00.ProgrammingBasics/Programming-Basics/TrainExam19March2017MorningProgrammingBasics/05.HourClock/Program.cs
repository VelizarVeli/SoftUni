using System;

namespace Zadacha_05
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int dos = 0;

            Console.WriteLine(new string('*', 2 * n + 1));

            Console.Write(".*");
            Console.Write(new string(' ', 2 * n - 3));
            Console.WriteLine("*.");

            for (int top = 0; top < n - 2; top++)
            {
                Console.Write(new string('.', 2 + top));
                Console.Write("*");
                Console.Write(new string('@', (2 * n) - 5 - dos));
                Console.Write("*");
                Console.WriteLine(new string('.', 2 + top));

                dos += 2;
            }

            Console.Write(new string('.', n));
            Console.Write("*");
            Console.WriteLine(new string('.', n));

            for (int bot = 0; bot < n - 2; bot++)
            {
                Console.Write(new string('.', n - 1 - bot));
                Console.Write("*");
                Console.Write(new string(' ', bot));
                Console.Write("@");
                Console.Write(new string(' ', bot));
                Console.Write("*");
                Console.WriteLine(new string('.', n - 1 - bot));
            }

            Console.Write(".*");
            Console.Write(new string('@', 2 * n - 3));
            Console.WriteLine("*.");

            Console.WriteLine(new string('*', 2 * n + 1));
        }
    }
}