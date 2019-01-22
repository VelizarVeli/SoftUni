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
            double counter4 = 0;
            double counter5 = 0;
            

            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (num < 200)
                {
                    counter1++;
                }
                else if (num < 400)
                {
                    counter2++;
                }
                else if (num < 600)
                {
                    counter3++;
                }
                else if (num < 800)
                {
                    counter4++;
                }
                else if (num >= 800)
                {
                    counter5++;
                }
            }
            Console.WriteLine($"{(counter1 * 100) / n:f2}%");
            Console.WriteLine($"{(counter2 * 100) / n:f2}%");
            Console.WriteLine($"{(counter3 * 100) / n:f2}%");
            Console.WriteLine($"{(counter4 * 100) / n:f2}%");
            Console.WriteLine($"{(counter5 * 100) / n:f2}%");
        }
    }
}
