using System;

namespace _06.TwoNumbersSume
{
    class Program
    {
        static void Main()
        {
            int M = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int counter = 0;
            int M1 = 0;
            int M2 = 0;
            for (int i = M; i >= L; i--)
            {
                for (int j = M; j >= L; j--)
                {
                    M1 = j;
                    M2 = i;
                        counter++;
                    if (i + j == number)
                    {
                        break;
                    }
                }
                if (i + M1 == number)
                {
                    break;
                }
            }
            if (M1 + M2 == number)
            {
                Console.WriteLine($"Combination N:{counter} ({M2} + {M1} = {number})");
            }
            else
                Console.WriteLine($"{counter} combinations - neither equals {number}");

        }
    }
}
