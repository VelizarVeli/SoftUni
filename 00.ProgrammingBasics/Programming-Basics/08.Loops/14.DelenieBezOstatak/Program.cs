using System;

namespace _13.Histogram
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double counter1 = 0;
            double counter2 = 0;
            double counter3 = 0;


            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    counter1++;
                }
                if (num % 3 == 0)
                {
                    counter2++;
                }
                if (num % 4 == 0)
                {
                    counter3++;
                }
            }
            Console.WriteLine($"{(counter1 * 100) / n:f2}%");
            Console.WriteLine($"{(counter2 * 100) / n:f2}%");
            Console.WriteLine($"{(counter3 * 100) / n:f2}%");
        }
    }
}
