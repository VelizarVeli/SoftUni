using System;
using System.Linq;

namespace testy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NAndM = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int N = NAndM[0];
            int M = NAndM[1];
            char[,] matrix = new char[N, M];
            char[] snake = Console.ReadLine().ToCharArray();
            int[] shot = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            bool first = true;
            int index = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (first)
                {
                    for (int colReversed = matrix.GetLength(1) - 1; colReversed >= 0; colReversed--)
                    {
                        matrix[row, colReversed] = snake[index % snake.Length];
                        index++;
                    }
                    first = false;
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int snakeIndex = index % snake.Length;
                        matrix[row, col] = snake[snakeIndex];
                        index++;
                    }
                    first = true;
                }
            }

            int rowShot = shot[0];
            int colShot = shot[1];
            int radiusShot = shot[2];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    int a = rowShot - r;
                    int b = colShot - column;

                    double distance = Math.Sqrt(a * a + b * b);
                    if (distance <= radiusShot)
                    {
                        matrix[r, column] = ' ';
                    }
                }
            }

            matrix = Gravity(matrix);



            //for (int row = matrix.GetLength(0) - 1; row >= 1; row--)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        if (matrix[row, col] == ' ')
            //        {


            //            //matrix[row, col] = matrix[row - 1, col];
            //            //matrix[row - 1, col] = ' ';
            //        }
            //    }
            //}
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] Gravity(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int emptyRows = 0;
                for (int row = matrix.GetLength(0) - 1; row >= 0 ; row--)
                {
                    if (matrix[row,col] == ' ')
                    {
                        emptyRows++;
                    }
                    else if(emptyRows > 0)
                    {
                        matrix[row + emptyRows, col] = matrix[row, col];
                        matrix[row, col] = ' ';
                    }
                }
            }
            return matrix;
        }
    }
}
