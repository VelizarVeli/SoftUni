using System;

namespace _06.DNASequence
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            char A = (char)65;
            char C = (char)67;
            char G = (char)71;
            char T = (char)84;

            char somethingI = '4';
            char somethingJ = '4';
            char somethingK = '4';


            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        if (i == 1)
                        {
                            somethingI = A;
                        }
                        else if (i == 2)
                        {
                            somethingI = C;
                        }
                        else if (i == 3)
                        {
                            somethingI = G;
                        }
                        else if (i == 4)
                        {
                            somethingI = T;
                        }

                        if (j == 1)
                        {
                            somethingJ = A;
                        }
                        else if (j == 2)
                        {
                            somethingJ = C;
                        }
                        else if (j == 3)
                        {
                            somethingJ = G;
                        }
                        else if (j == 4)
                        {
                            somethingJ = T;
                        }

                        if (k == 1)
                        {
                            somethingK = A;
                        }
                        else if (k == 2)
                        {
                            somethingK = C;
                        }
                        else if (k == 3)
                        {
                            somethingK = G;
                        }
                        else if (k == 4)
                        {
                            somethingK = T;
                        }
                        if (i + j + k >= num)
                        {
                            Console.Write($"O{somethingI}{somethingJ}{somethingK}O ");
                        }
                        else
                        {
                            Console.Write($"X{somethingI}{somethingJ}{somethingK}X ");
                        }
                    }
                Console.WriteLine();
                }
            }
        }
    }
}
