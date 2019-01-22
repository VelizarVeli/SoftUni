using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (col == 0 || row == 7)
                    {
                        Console.Write($"o ");
                    }
                    else
                    {
                        Console.Write($" ");

                    }
                }
                Console.WriteLine();
            }
        }
    }
}
