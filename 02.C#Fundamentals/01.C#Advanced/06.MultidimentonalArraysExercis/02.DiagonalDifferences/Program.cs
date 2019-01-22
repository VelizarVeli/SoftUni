using System;
using System.Linq;

namespace _02.DiagonalDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[,] matrix = new int[N, N];
            for (int row = 0; row < N; row++)
            {
                int[] rows = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int column = 0; column < rows.Length; column++)
                {
                    matrix[row, column] = rows[column];
                }
            }
            int primarySum = 0;
            int primaryRowIndex = 0;
            int primaryColumnIndex = 0;

            int secondarySum = 0;
            int secondaryRowIndex = 0;
            int secondaryColumnIndex = matrix.GetLength(0) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    int number = matrix[row, column];
                    if (row == primaryRowIndex && column == primaryColumnIndex)
                    {
                        primarySum += number;
                        primaryRowIndex++;
                        primaryColumnIndex++;
                    }
                    if (row == secondaryRowIndex && column == secondaryColumnIndex)
                    {
                        secondarySum += number;
                        secondaryRowIndex++;
                        secondaryColumnIndex--;
                    }
                }
            }
            Console.WriteLine($"{Math.Abs(primarySum -secondarySum)}");
        }
    }
}
