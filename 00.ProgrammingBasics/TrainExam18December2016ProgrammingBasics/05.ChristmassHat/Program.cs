    using System;

    namespace _05.ChristmassHat
    {
        class Program
        {
            static void Main()
            {
                int n = int.Parse(Console.ReadLine());
                int tochki = 2 * n - 2;
                int tireta = 1;

                Console.WriteLine(@"{0}/|\{0}", new string('.',n * 2 - 1));
                Console.WriteLine(@"{0}\|/{0}", new string('.',n * 2 - 1));
                Console.WriteLine("{0}***{0}", new string('.', n * 2 - 1));
                for (int i = 0; i < n * 2 - 2; i++)
                {
                    Console.WriteLine("{0}*{1}*{1}*{0}", new string('.',tochki), new string('-',tireta));
                    tochki--;
                    tireta++;
                }
            Console.WriteLine("*{0}*{0}*",new string('-', tireta));
                Console.WriteLine(new string('*', 4 * n + 1));
                for (int i = 0; i < n * 2; i++)
                {
                    Console.Write("*.");
                }
                Console.WriteLine("*");
                Console.WriteLine(new string('*', 4 * n + 1));
            }
        }
    }
