using System;

namespace _06.ControlNumber
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int control = int.Parse(Console.ReadLine());

            int counter = 0;
            int sum = 0;
            int sum1 = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = M; j >= 1; j--)
                {
                    sum = (i * 2) + (j * 3); 
                    sum1 = sum + sum1;
                    counter++;
                    if(sum1 >= control)
                    {
                        break;
                    }
                }
                if (sum1 >= control)
                {
                    break;
                }
            }
            if (sum1 < control)
            {
                Console.WriteLine($"{counter} moves");
            }
            else if(sum1 >= control)
            {
                Console.WriteLine($"{counter} moves");
                Console.WriteLine($"Score: {sum1} >= {control}");
            }
        }
    }
}
