using System;

namespace test
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int tochki = 2;
            int gorniCliombi = 2 * N - 1;
            int space = 1;
            int dolniTochki = N - 2;

            Console.WriteLine(new string('*', 2 * N + 1));
            Console.Write(".*");
            Console.Write(new string(' ', 2 * N - 3));
            Console.WriteLine("*.");

            for (int i = 1; i < N - 1; i++)
            {
                Console.Write(new string('.', tochki));
                Console.Write('*');
                if (gorniCliombi > 0)
                {
                    Console.Write(new string('@', gorniCliombi - 4));
                    gorniCliombi -= 2;
                }
                Console.Write('*');
                Console.Write(new string('.', tochki));
                tochki++;
                
                Console.WriteLine();
                if (gorniCliombi < 1)
                    break;
            }
            Console.WriteLine("{0}*{0}",new string('.',N));
            Console.WriteLine("{0}*@*{0}", new string('.', N - 1));

            for (int i = 1; i < N - 2; i++)
            {
                Console.WriteLine("{0}*{1}@{1}*{0}", new string('.', dolniTochki), new string(' ', space));
                space++;
                dolniTochki--;
            }
            Console.WriteLine(".*{0}*.",new string('@', 2 * N - 3));
            Console.WriteLine(new string('*', 2 * N + 1));
        }
    }
}
