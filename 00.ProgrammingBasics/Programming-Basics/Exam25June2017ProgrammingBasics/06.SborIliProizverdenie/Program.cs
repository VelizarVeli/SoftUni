using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SborIliProizverdenie
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            bool YN = true;
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 1; j <= 30; j++)
                {
                    for (int k = 1; k <= 30; k++)
                    {
                        if (i + j + k == N && i < j && j < k)
                        {
                            Console.WriteLine($"{i} + {j} + {k} = {N}");
                            YN = false;
                        }
                        if (i * j * k == N && i > j && j > k)
                        {
                            Console.WriteLine($"{i} * {j} * {k} = {N}");
                            YN = false;
                        }
                    }
                }
            }
            if (YN)
            {
                Console.WriteLine("No!");
            }
        }
    }
}
