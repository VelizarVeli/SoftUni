using System;

namespace _05.Rocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int tochki = (3 * n - 2) / 2;
            int spaces = 2;
            char backslash = '\\';
            for (int i = 1; i <= n; i++)
            {
                if(i == 1)
                {
                    Console.WriteLine("{0}/\\{0}",new string('.',tochki));
                    tochki--;
                }
                else
                {
                    Console.WriteLine("{0}/{1}\\{0}", new string('.', tochki), new string(' ', spaces));
                    tochki--;
                    spaces += 2;
                }
            }
            tochki++;
            Console.WriteLine("{0}{1}{0}", new string('.', tochki), new string('*', 2 * n));
            for (int i = 1; i <= 2 * n; i++)
            {
                Console.WriteLine("{0}|{1}|{0}",new string('.', tochki), new string(backslash, 2 * n - 2));
            }
            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', tochki), new string('*', 3 * n - tochki * 2 - 2));
                tochki--;
            }
        }
    }
}
