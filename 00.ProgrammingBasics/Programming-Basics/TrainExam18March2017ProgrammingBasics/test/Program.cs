using System;

namespace _06.SumOfTwoNumbers
{
    class Program
    {
        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int counter = 0;

            int i = 0;
            int j = 1;
            bool check = false;

            for (i = num1; i <= num2; i++)
            {
                for (j = num1; j <= num2; j++)
                {
                    counter++;
                    if (i + j == magic)
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {

                    break;
                }
            }
            if (check)
            {
                Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magic})");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {magic}");
            }
        }
    }
}
