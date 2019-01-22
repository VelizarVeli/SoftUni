using System;

namespace _07.ChristmassTree
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i <= n; i++)
            {
                Console.Write(new string(' ', n - i));
                Console.Write(new string('*', i));
                Console.Write(" ");
                Console.Write("|");
                Console.Write(" ");
                Console.Write(new string('*', i));
                Console.WriteLine(new string(' ', n));
                Console.WriteLine();
            }
        }
    }
}
