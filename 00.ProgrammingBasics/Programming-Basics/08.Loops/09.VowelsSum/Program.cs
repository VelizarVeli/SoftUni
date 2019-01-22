using System;

namespace _09.VowelsSum
{
    class Program
    {
        static void Main()
        {
            string x = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i <= x.Length - 1; i++)
            {
               
                if (x[i] == 'a')
                {
                    sum += 1;
                }
                else if (x[i] == 'e')
                {
                    sum += 2;
                }
                else if (x[i] == 'i')
                {
                    sum += 3;
                }
                else if (x[i] == 'o')
                {
                    sum += 4;
                }
                else if (x[i] == 'u')
                {
                    sum += 5;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
