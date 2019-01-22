using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int shirina = (4 * n) + 1;
            int tochki = 1;
            int karetki = n * 2 - 1;
            int space = 1;

            Console.WriteLine($"{new string('#', shirina)}");
            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', tochki), new string('#', karetki), new string(' ', space));
                tochki++;
                karetki -= 2;
                space += 2;
            }

            Console.WriteLine("{0}{1}{2}(@){2}{1}{0}", new string('.', tochki), new string('#', karetki), new string(' ', space / 2 - 1));
            tochki++;
            karetki -= 2;
            space += 2;


            if (n % 2 == 0)
            for (int i = 1; i <= n / 2 - 1; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', tochki), new string('#', karetki), new string(' ', space));
                tochki++;
                karetki -= 2;
                space += 2;
            }
            else
            {
                for (int i = 1; i <= n / 2; i++)
                {
                    Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', tochki), new string('#', karetki), new string(' ', space));
                    tochki++;
                    karetki -= 2;
                    space += 2;
                }
            }
            karetki = n * 2 - 1;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', tochki), new string('#', karetki));
                tochki++;
                karetki -= 2;
            }
        }
    }
}
