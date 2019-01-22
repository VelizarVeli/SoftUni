using System;
using System.Linq;

namespace testy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            char a = 'a';
            char b = 'a';

            string[,] matrix = new string[rowsAndColumns[0], rowsAndColumns[1]];

            for (int row = 0; row < rowsAndColumns[0]; row++)
            {
                for (int column = 0; column < rowsAndColumns[1]; column++)
                {

                    matrix[row, column] = ($"{a}{b}{a} ");
                    b++;
                }
                a++;
                b = a;
            }
            for (int row = 0; row < rowsAndColumns[0]; row++)
            {
                for (int column = 0; column < rowsAndColumns[1]; column++)
                {

                    Console.Write(matrix[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}
