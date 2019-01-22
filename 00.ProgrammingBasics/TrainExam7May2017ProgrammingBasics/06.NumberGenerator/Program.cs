using System;

namespace _06.NumberGenerator
{
    class Program
    {
        static void Main()
        {
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int special = int.Parse(Console.ReadLine());
            int control = int.Parse(Console.ReadLine());


            for (int i = M; i >= 1; i--)
            {
                for (int j = N; j >= 1; j--)
                {
                    for (int k = L; k >= 1; k--)
                    {
                        int number = i * 100 + j * 10 + k;

                        if (number % 3 == 0)
                        {
                            special += 5;
                        }
                        else if (k == 5)
                        {
                            special -= 2;
                        }
                        else if (number % 2 == 0)
                        {
                            special *= 2;
                        }
                        if (special >= control)
                        {
                            break;
                        }
                    }
                    if (special >= control)
                    {
                        break;
                    }
                }
                if (special >= control)
                {
                    break;
                }
            }
            if (special >= control)
            {
                Console.WriteLine($"Yes! Control number was reached! Current special number is {special}.");
            }
            else
                Console.WriteLine($"No! {special} is the last reached special number.");
        }
    }
}
