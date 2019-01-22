using System;
using System.Linq;

namespace _03._2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            char[,] matrix = new char[rowsAndCols[0], rowsAndCols[1]];

            for (int row = 0; row < rowsAndCols[0] ; row++)
            {
                char[] rowses = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int column = 0; column < rowses.Length; column++)
                {
                    matrix[row, column] = rowses[column];
                }
            }
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) -1; column++)
                {
                    char current = matrix[row, column];
                    char currentRight = matrix[row, column + 1];
                    char currentDown = matrix[row + 1, column];
                    char currentRightDown = matrix[row + 1, column + 1];

                    if (current == currentRight && current == currentDown && current == currentRightDown)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
