using System;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    for (int letter1 = 1; letter1 <= l; letter1++)
                    {
                        for (int letter2 = 1; letter2 <= l; letter2++)
                        {

                            for (int k = ((int)Math.Max(i, j) + 1); k <= n; k++)
                            {
                                Console.Write(i + "" + j + "" + ((char)(letter1 + 96)) + ((char)(letter2 + 96)) + k + " ");
                            }
                        }
                    }
                }
            }
        }
    }
}
