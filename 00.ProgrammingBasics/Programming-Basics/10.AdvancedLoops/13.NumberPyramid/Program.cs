using System;

namespace _13.NumberPyramid
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                        Console.Write($"{num} ");
                        num++;
                        if (num > n)
                            break;
                    
                }
                Console.WriteLine();
                if (num > n)
                    break;
            }
        }
    }
}
