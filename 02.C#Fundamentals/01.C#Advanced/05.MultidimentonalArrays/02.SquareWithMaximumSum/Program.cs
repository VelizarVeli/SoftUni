using System;
using System.Linq;

namespace _02.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int row = 0; row < rowsAndColumns[0]; row++)
            {
                int[] rowses = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int column = 0; column < rowsAndColumns[1]; column++)
                {
                    int current = rowses[column];
                    matrix[row, column] = current;
                }
            }
            int upperLeftMax = Int32.MinValue;
            int upperRightMax = Int32.MinValue;
            int bottomLeftMax = Int32.MinValue;
            int bottomRightMax = Int32.MinValue;
            int sum = Int32.MinValue;
            for (int row = 0; row < rowsAndColumns[0] - 1; row++)
            {
                for (int column = 0; column < rowsAndColumns[1] - 1; column++)
                {
                    int current = matrix[row, column];
                    int currentSum = current + matrix[row, column+1] + matrix[row+1, column] +
                                     matrix[row + 1, column + 1];
                    if (sum < currentSum)
                    {
                        sum = currentSum;
                        upperLeftMax = current;
                        upperRightMax = matrix[row, column+1];
                        bottomLeftMax = matrix[row+1, column];
                        bottomRightMax = matrix[row + 1, column + 1];
                    }
                }
            }
            Console.WriteLine($"{upperLeftMax} {upperRightMax}");
            Console.WriteLine($"{bottomLeftMax} {bottomRightMax}");
            Console.WriteLine(sum);
        }
    }
}
