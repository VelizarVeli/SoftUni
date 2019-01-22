using System;
using System.Linq;
/ 80/100
namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToArray();
            long[,] matrix = new long[rowsAndCols[0], rowsAndCols[1]];
            for (int rows = 0; rows < rowsAndCols[0]; rows++)
            {
                long[] rowses = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse).ToArray();
                for (int columns = 0; columns < rowses.Length; columns++)
                {
                    matrix[rows, columns] = rowses[columns];
                }
            }
            long sum = Int64.MinValue;
            long LeftUp = Int32.MinValue;
            long MiddleUp = Int32.MinValue;
            long RightUp = Int32.MinValue;
            long MiddleLeft = Int32.MinValue;
            long MiddleMiddle = Int32.MinValue;
            long MiddleRight = Int32.MinValue;
            long DownLeft = Int32.MinValue;
            long DownMiddle = Int32.MinValue;
            long DownRight = Int32.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    long currentLeftUp = matrix[row, col];
                    long currentMiddleUp = matrix[row, col + 1];
                    long currentRightUp = matrix[row, col + 2];
                    long currentMiddleLeft = matrix[row + 1, col];
                    long currentMiddleMiddle = matrix[row + 1, col + 1];
                    long currentMiddleRight = matrix[row + 1, col + 2];
                    long currentDownLeft = matrix[row + 2, col];
                    long currentDownMiddle = matrix[row + 2, col + 1];
                    long currentDownRight = matrix[row + 2, col + 2];
                    long currentSum = currentLeftUp + currentMiddleUp + currentRightUp + currentMiddleLeft + currentMiddleMiddle
                        + currentMiddleRight + currentDownLeft + currentDownMiddle + currentDownRight;
                    if (currentSum >= sum)
                    {
                        sum = currentSum;
                        LeftUp = currentLeftUp;
                        MiddleUp = currentMiddleUp;
                        RightUp = currentRightUp;

                        MiddleLeft = currentMiddleLeft;
                        MiddleMiddle = currentMiddleMiddle;
                        MiddleRight = currentMiddleRight;

                        DownLeft = currentDownLeft;
                        DownMiddle = currentDownMiddle;
                        DownRight = currentDownRight;
                    }
                }
            }
            
                Console.WriteLine($"Sum = {sum}");
                Console.WriteLine($"{LeftUp} {MiddleUp} {RightUp}");
                Console.WriteLine($"{MiddleLeft} {MiddleMiddle} {MiddleRight}");
                Console.WriteLine($"{DownLeft} {DownMiddle} {DownRight}");
            
        }
    }
}
